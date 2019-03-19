using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.News;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Shared;
using CSM.Bataan.School.WebSite.Infrastructure.Data.BusinessObjects;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class NewsController : Controller
    {
        private readonly DefaultDbContext _context;
        private IHostingEnvironment _env;

        public NewsController(DefaultDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [Authorize(Policy = "AuthorizeContentAdmin")]
        [HttpGet, Route("manage/news/index")]
        [HttpGet, Route("manage/news")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 2, string keyword = "")
        {
            Page<NewsFeedItem> result = new Page<NewsFeedItem>();

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IQueryable<NewsItem> newsQuery = (IQueryable<NewsItem>)this._context.News;

            if (string.IsNullOrEmpty(keyword) == false)
            {
                newsQuery = newsQuery.Where(u => u.Title.ToLower().Contains(keyword.ToLower()));
            }

            long queryCount = newsQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<NewsItem> news = newsQuery.ToList();


            result.Items = news.Skip(skip).Take((int)pageSize).Select(n => new NewsFeedItem() {
                Id = n.Id,
                Description = n.Description,
                Timestamp = n.Timestamp,
                Title = n.Title,
                UserId = n.UserId,
                IsPublished = n.IsPublished,
                PostExpiry = n.PostExpiry
            }).OrderByDescending(n => n.Timestamp).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;

            //Get User Names
            foreach (NewsFeedItem item in result.Items)
            {
                var user = this._context.Users.FirstOrDefault(u => u.Id == item.UserId);

                if (user != null)
                {
                    item.UserName = user.FullName;
                }
            }

            return View(new IndexViewModel()
            {
                News = result
            });
        }

        [Authorize(Policy = "AuthorizeContentAdmin")]
        [HttpPost, Route("manage/news/update-{type}")]
        public async Task<IActionResult> UpdateImage(UpdateImageViewModel model, string type)
        {
            var fileSize = model.ImageFile.Length;
            if ((fileSize / 1048576.0) > 2)
            {
                ModelState.AddModelError("", "The file you uploaded is too large. Filesize limit is 2mb.");
                return View(model);
            }

            if (model.ImageFile.ContentType != "image/jpeg" && model.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("", "Please upload a jpeg or png file for the thumbnail.");
                return View(model);
            }

            var dirPath = _env.WebRootPath + "/news/" + model.Id.ToString();
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            var filePath = dirPath + "/" + type + ".png";

            var width = 75;
            var height = 75;

            switch (type.ToLower())
            {
                case "thumbnail":
                    width = 75;
                    height = 75;
                    break;
                case "banner":
                    width = 500;
                    height = 150;
                    break;
            }

            if (model.ImageFile.Length > 0)
            {
                byte[] bytes = await FileBytes(model.ImageFile.OpenReadStream());
                using (Image<Rgba32> image = Image.Load(bytes))
                {
                    image.Mutate(x => x.Resize(width, height));
                    image.Save(filePath);
                }
            }
            return RedirectPermanent("~/manage/news?" + model.Filters);
        }

        public async Task<byte[]> FileBytes(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        [Authorize(Policy = "AuthorizeContentAdmin")]
        [HttpPost, Route("manage/news/update-publish-status")]
        public IActionResult UpdatePublishStatus(PublishUnpublishViewModel model)
        {
            var newsItem = this._context.News.FirstOrDefault(n => n.Id == model.Id);

            if (newsItem != null)
            {
                newsItem.IsPublished = model.IsPublished;

                this._context.News.Update(newsItem);

                this._context.SaveChanges();
            }

            return RedirectPermanent("~/manage/news?" + model.Filters);
        }

        [Authorize(Policy = "AuthorizeContentAdmin")]
        [HttpPost, Route("manage/news/update-title")]
        public IActionResult UpdateTitle(UpdateTitleViewModel model)
        {
            var newsItem = this._context.News.FirstOrDefault(n => n.Id == model.Id);

            if (newsItem != null)
            {
                newsItem.Title = model.Title;
                newsItem.Description = model.Description;
                newsItem.PostExpiry = model.PostExpiry;

                this._context.News.Update(newsItem);

                this._context.SaveChanges();
            }

            return RedirectPermanent("~/manage/news?" + model.Filters);
        }

        [Authorize(Policy = "AuthorizeContentAdmin")]
        [HttpGet, Route("manage/news/news-groups/{newsId}")]
        public IActionResult NewsGroups(Guid? newsId)
        {
            IQueryable<Group> groupQuery = (IQueryable<Group>)this._context.Groups;

            var groupIds = this._context.NewsGroups.Where(ng => ng.NewsItemId == newsId).Select(ng => ng.GroupId).ToList();

            groupQuery = groupQuery.Where(g => groupIds.Contains(g.Id.Value));

            long queryCount = groupQuery.Count();

            List<Group> groups = groupQuery.ToList();

            NewsItem news = this._context.News.FirstOrDefault(u => u.Id == newsId);

            return View(new NewGroupsIndexViewModel()
            {
                NewsId = newsId,
                NewsTitle = (news != null ? news.Title : ""),
                Groups = groups
            });
        }

        [Authorize(Policy = "AuthorizeContentAdmin")]
        [HttpPost, Route("manage/news/news-groups/add")]
        public IActionResult AddNewsGroups(AddRemoveGroupViewModel model)
        {
            var duplicate = this._context.NewsGroups.FirstOrDefault(ng => ng.GroupId == model.GroupId && ng.NewsItemId == model.Id);

            if (duplicate == null)
            {
                var newsGroup = new NewsGroup()
                {
                    NewsItemId = model.Id,
                    GroupId = model.GroupId
                };

                this._context.NewsGroups.Add(newsGroup);

                this._context.SaveChanges();
            }

            return RedirectPermanent("~/manage/news/news-groups/" + model.Id);
        }

        [Authorize(Policy = "AuthorizeContentAdmin")]
        [HttpPost, Route("manage/news/news-groups/remove")]
        public IActionResult RemoveNewsGroups(AddRemoveGroupViewModel model)
        {
            var newsGroup = this._context.NewsGroups.FirstOrDefault(ng => ng.GroupId == model.GroupId && ng.NewsItemId == model.Id);

            if (newsGroup != null)
            {
                this._context.NewsGroups.Remove(newsGroup);

                this._context.SaveChanges();
            }

            return RedirectPermanent("~/manage/news/news-groups/" + model.Id);
        }

        [Authorize(Policy = "AuthorizeContentAdmin")]
        [HttpGet, Route("/manage/news/update-content/{newsId}")]
        public IActionResult UpdateContent(Guid? newsId)
        {
            var newsItem = this._context.News.FirstOrDefault(n => n.Id == newsId);
            if (newsItem != null)
            {
                return View(new UpdateContentViewModel()
                {
                    Id = newsItem.Id,
                    Title = newsItem.Title,
                    Content = newsItem.Content
                });
            }
            return RedirectToAction("index");
        }

        [Authorize(Policy = "AuthorizeContentAdmin")]
        [HttpPost, Route("/manage/news/update-content/")]
        public IActionResult UpdateContent(UpdateContentViewModel model)
        {
            var newsItem = this._context.News.FirstOrDefault(n => n.Id == model.Id);
            if (newsItem != null)
            {
                newsItem.Content = model.Content;
                newsItem.Timestamp = DateTime.UtcNow;
                this._context.News.Update(newsItem);
                this._context.SaveChanges();
            }
            return RedirectToAction("index");
        }

        [Authorize(Policy = "AuthorizeContentAdmin")]
        [HttpGet, Route("manage/news/create")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "AuthorizeContentAdmin")]
        [HttpPost, Route("manage/news/create")]
        public IActionResult Create(CreateContentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            NewsItem newsItem = new NewsItem()
            {
                Id = Guid.NewGuid(),
                Content = model.Content,
                Description = model.Description,
                IsPublished = false,
                PostExpiry = model.PostExpiry,
                Title = model.Title
            };

            this._context.News.Add(newsItem);
            this._context.SaveChanges();

            return View();
        }


    }
}