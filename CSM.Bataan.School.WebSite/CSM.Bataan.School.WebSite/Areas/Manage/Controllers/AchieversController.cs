using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Achievers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AchieversController : Controller
    {
        private readonly DefaultDbContext _context;
        private IHostingEnvironment _env;
        public AchieversController(DefaultDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet, Route("manage/achievers/index")]
        [HttpGet, Route("manage/achievers")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 10, string keyword = "")
        {

            Page<Achiever> result = new Page<Achiever>();
            if (pageSize < 1)
            {
                pageSize = 1;
            }
            IQueryable<Achiever> achieverQuery = (IQueryable<Achiever>)this._context.Achievers;
            if (string.IsNullOrEmpty(keyword) == false)
            {
                achieverQuery = achieverQuery.Where(u => u.Title.ToLower().Contains(keyword.ToLower()));
            }
            long queryCount = achieverQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<Achiever> users = achieverQuery.ToList();

            result.Items = users.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;


            return View(new IndexViewModel()
            {
                Achievers = result
            });
        }


        [HttpGet, Route("manage/achievers/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("manage/achievers/create")]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
           Achiever achiever = new Achiever()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Content = model.Content,
                PostExpiry = model.PostExpiry,
                IsPublished = true,
                TemplateName = "achiever1"




            };
            this._context.Achievers.Add(achiever);
            this._context.SaveChanges();
            return View();
        }


        [HttpPost, Route("manage/achievers/unpublish")]
        public IActionResult Unpublish(AchieverIdViewModel model)
        {
            var achiever = this._context.Achievers.FirstOrDefault(t => t.Id == model.Id);
            if (achiever != null)
            {
                achiever.IsPublished = false;
                this._context.Achievers.Update(achiever);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }

        [HttpPost, Route("manage/achievers/publish")]
        public IActionResult Publish(AchieverIdViewModel model)
        {
            var achiever = this._context.Achievers.FirstOrDefault(t => t.Id == model.Id);

            if (achiever != null)
            {
                achiever.IsPublished = true;
                this._context.Achievers.Update(achiever);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }


        [HttpGet, Route("/manage/achievers/update-title/{achieverId}")]
        public IActionResult UpdateTitle(Guid? achieverId)
        {
            var achiever = this._context.Achievers.FirstOrDefault(p => p.Id == achieverId);
            if (achiever != null)
            {
                var model = new UpdateTitleViewModel()
                {
                    Id = achiever.Id,
                    Title = achiever.Title,
                    PostExpiry = achiever.PostExpiry,
                  

                };
                return View(model);
            }
            return RedirectToAction("Create");
        }

        [HttpPost, Route("/manage/achievers/update-title")]
        public IActionResult UpdateTitle(UpdateTitleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var achiever = this._context.Achievers.FirstOrDefault(p => p.Id == model.Id);

            if (achiever != null)
            {
                achiever.PostExpiry = model.PostExpiry;
                achiever.Title = model.Title;
               

                this._context.Achievers.Update(achiever);
                this._context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet, Route("/manage/achievers/update-content/{achieverId}")]
        public IActionResult UpdateContent(Guid? achieverId)
        {
            var achiever = this._context.Achievers.FirstOrDefault(t => t.Id == achieverId);
            if (achiever != null)
            {
                return View(new UpdateContentViewModel()
                {
                    AchieverId = achiever.Id,
                    Title = achiever.Title,
                    Content = achiever.Content
                });
            }
            return RedirectToAction("Index");
        }
        [HttpPost, Route("/manage/achievers/update-content/")]
        public IActionResult UpdateContent(UpdateContentViewModel model)
        {
            var achiever = this._context.Achievers.FirstOrDefault(t => t.Id == model.AchieverId);
            if (achiever != null)
            {

                achiever.Content = model.Content;
                achiever.Timestamp = DateTime.UtcNow;
                this._context.Achievers.Update(achiever);
                this._context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet, Route("/manage/achievers/update-banner/{achieverId}")]
        public IActionResult Banner(Guid? achieverId)
        {
            return View(new BannerViewModel() { AchieverId = achieverId });
        }
        [HttpPost, Route("/manage/achievers/update-banner")]
        public async Task<IActionResult> Banner(BannerViewModel model)
        {
            var fileSize = model.Banner.Length;
            if ((fileSize / 1048576.0) > 5)
            {
                ModelState.AddModelError("", "The file you uploaded is too large. Filesize limit is 5mb.");
                return View(model);
            }
            if (model.Banner.ContentType != "image/jpeg" && model.Banner.ContentType != "image/png")
            {
                ModelState.AddModelError("", "Please upload a jpeg or png file for the banner.");
                return View(model);
            }
            var dirPath = _env.WebRootPath + "/images/achievers/" + model.AchieverId.ToString();
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            var filePath = dirPath + "/banner.png";
            if (model.Banner.Length > 0)
            {
                byte[] bytes = await FileBytes(model.Banner.OpenReadStream());
                using (Image<Rgba32> image = Image.Load(bytes))
                {
                    image.Mutate(x => x.Resize(750, 300));
                    image.Save(filePath);
                }
            }
            return RedirectToAction("Banner", new { AchieverId = model.AchieverId });
        }









        [HttpGet, Route("/manage/achievers/update-thumbnail/{achieverId}")]
        public IActionResult Thumbnail(Guid? achieverId)
        {
            return View(new ThumbnailViewModel() { AchieverId = achieverId });
        }
        [HttpPost, Route("/manage/achievers/update-thumbnail")]
        public async Task<IActionResult> Thumbnail(ThumbnailViewModel model)
        {
            //Check file size of the uploaded thumbnail
            //reject if the file is greater than 2mb
            var fileSize = model.Thumbnail.Length;
            if ((fileSize / 1048576.0) > 2)
            {
                ModelState.AddModelError("", "The file you uploaded is too large. Filesize limit is 2mb.");
                return View(model);
            }
            //Check file type of the uploaded thumbnail
            //reject if the file is not a jpeg or png
            if (model.Thumbnail.ContentType != "image/jpeg" && model.Thumbnail.ContentType != "image/png")
            {
                ModelState.AddModelError("", "Please upload a jpeg or png file for the thumbnail.");
                return View(model);
            }
            //Formulate the directory where the file will be saved
            //create the directory if it does not exist
            var dirPath = _env.WebRootPath + "/images/achievers/" + model.AchieverId.ToString();
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            //always name the file thumbnail.png
            var filePath = dirPath + "/thumbnail.png";
            if (model.Thumbnail.Length > 0)

            {
                //Open a file stream to read all the file data into a byte array
                byte[] bytes = await FileBytes(model.Thumbnail.OpenReadStream());
                //load the file into the third party (ImageSharp) Nuget Plugin                
                using (Image<Rgba32> image = Image.Load(bytes))
                {
                    //use the Mutate method to resize the image 150px wide by 150px long
                    image.Mutate(x => x.Resize(150, 150));
                    //save the image into the path formulated earlier
                    image.Save(filePath);
                }
            }
            return RedirectToAction("Thumbnail", new { AchieverId = model.AchieverId });
        }


        //this method is used to load the file stream into 
        //a byte array
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

        [HttpPost, Route("/manage/achievers/attach-image")]
        public async Task<string> AttachImage(AttachImageViewModel model)
        {
            var fileSize = model.Image.Length;
            if ((fileSize / 1048576.0) > 5)
            {
                return "Error:The file you uploaded is too large. Filesize limit is 5mb.";
            }
            if (model.Image.ContentType != "image/jpeg" && model.Image.ContentType != "image/png")
            {
                return "Error:Please upload a jpeg or png file for the attachment.";
            }
            var dirPath = _env.WebRootPath + "/images/achievers/" + model.AchieverId.ToString();
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            var imgUrl = "/content_" + Guid.NewGuid().ToString() + ".png";
            var filePath = dirPath + imgUrl;
            if (model.Image.Length > 0)
            {
                byte[] bytes = await FileBytes(model.Image.OpenReadStream());
                using (Image<Rgba32> image = Image.Load(bytes))
                {
                    //if image wider than 800 px scale to its aspect ratio
                    if (image.Width > 800)
                    {
                        var ratio = 800 / image.Width;
                        image.Mutate(x => x.Resize(800, Convert.ToInt32(image.Height * ratio)));
                    }
                    image.Save(filePath);
                }
            }
            return "OK:/achievers/" + model.AchieverId.ToString() + "/" + imgUrl;
        }
    }
}