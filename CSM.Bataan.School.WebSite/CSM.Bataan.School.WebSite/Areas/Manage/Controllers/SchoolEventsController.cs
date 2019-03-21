using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.SchoolEvents;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Microsoft.AspNetCore.Authorization;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SchoolEventsController : Controller
    {
        private readonly DefaultDbContext _context;
        private IHostingEnvironment _env;

        public SchoolEventsController(DefaultDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("manage/schoolevents/index")]
        [HttpGet, Route("manage/schoolevents")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 10, string keyword = "")
        {

            Page<SchoolEvent> result = new Page<SchoolEvent>();
            if (pageSize < 1)
            {
                pageSize = 1;
            }
            IQueryable<SchoolEvent> schooleveQuery = (IQueryable<SchoolEvent>)this._context.SchoolEvents;
            if (string.IsNullOrEmpty(keyword) == false)
            {
                schooleveQuery = schooleveQuery.Where(u => u.Title.ToLower().Contains(keyword.ToLower()));
            }
            long queryCount = schooleveQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<SchoolEvent> users = schooleveQuery.ToList();

            result.Items = users.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;


            return View(new IndexViewModel()
            {
                SchoolEvents = result
            });
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("manage/schoolevents/create")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/schoolevents/create")]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            SchoolEvent schoolevent = new SchoolEvent()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                Content = model.Content,
                PostExpiry = model.PostExpiry,
                IsPublished = true,
                EventStart = model.EventStart,
                EventEnd = model.EventEnd




            };
            this._context.SchoolEvents.Add(schoolevent);
            this._context.SaveChanges();
            return View();
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/schoolevents/unpublish")]
        public IActionResult Unpublish(SchoolEventIdViewModel model)
        {
            var schoolevent = this._context.SchoolEvents.FirstOrDefault(p => p.Id == model.Id);
            if (schoolevent != null)
            {
                schoolevent.IsPublished = false;
                this._context.SchoolEvents.Update(schoolevent);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/schoolevents/publish")]
        public IActionResult Publish(SchoolEventIdViewModel model)
        {
            var schoolevent = this._context.SchoolEvents.FirstOrDefault(p => p.Id == model.Id);

            if (schoolevent != null)
            {
                schoolevent.IsPublished = true;
                this._context.SchoolEvents.Update(schoolevent);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("/manage/schoolevents/update-title/{schooleventId}")]
        public IActionResult UpdateTitle(Guid? schooleventId)
        {
            var schoolevent = this._context.SchoolEvents.FirstOrDefault(p => p.Id == schooleventId);
            if (schoolevent != null)
            {
                var model = new UpdateTitleViewModel()
                {
                    Id = schoolevent.Id,
                    Description = schoolevent.Description,
                    Title = schoolevent.Title,
                    PostExpiry = schoolevent.PostExpiry,
                    EventStart = schoolevent.EventStart,
                    EventEnd = schoolevent.EventEnd,
                

                };
                return View(model);
            }
            return RedirectToAction("Create");
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("/manage/schoolevents/update-title")]
        public IActionResult UpdateTitle(UpdateTitleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var schoolevent = this._context.SchoolEvents.FirstOrDefault(p => p.Id == model.Id);

            if (schoolevent != null)
            {
                schoolevent.Title = model.Title;
                schoolevent.Description = model.Description;
                schoolevent.PostExpiry = model.PostExpiry;
                schoolevent.EventStart = model.EventStart;
                schoolevent.EventEnd = model.EventEnd;

                this._context.SchoolEvents.Update(schoolevent);
                this._context.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("/manage/schoolevents/update-content/{schooleventId}")]
        public IActionResult UpdateContent(Guid? schooleventId)
        {
            var schoolevent = this._context.SchoolEvents.FirstOrDefault(t => t.Id == schooleventId);
            if (schoolevent != null)
            {
                return View(new UpdateContentViewModel()
                {
                    SchoolEventId = schoolevent.Id,
                    Title = schoolevent.Title,
                    Content = schoolevent.Content

                });
            }
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("/manage/schoolevents/update-content/")]
        public IActionResult UpdateContent(UpdateContentViewModel model)
        {
            var schoolevent = this._context.SchoolEvents.FirstOrDefault(t => t.Id == model.SchoolEventId);
            if (schoolevent != null)
            {
                schoolevent.Content = model.Content;
                schoolevent.Timestamp = DateTime.UtcNow;

                this._context.SchoolEvents.Update(schoolevent);
                this._context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("/manage/schoolevents/attach-image")]
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
            var dirPath = _env.WebRootPath + "/images/schoolevents/" + model.SchoolEventId.ToString();
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
            return "OK:/schoolevents/" + model.SchoolEventId.ToString() + "/" + imgUrl;
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("/manage/schoolevents/update-thumbnail/{schooleventId}")]
        public IActionResult Thumbnail(Guid? schooleventId)
        {
            return View(new ThumbnailViewModel() { SchoolEventId = schooleventId });
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("/manage/schoolevents/update-thumbnail")]
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
            var dirPath = _env.WebRootPath + "/images/schoolevents/" + model.SchoolEventId.ToString();
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
            return RedirectToAction("Thumbnail", new { SchoolEventId = model.SchoolEventId });
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("/manage/schoolevents/update-banner/{schooleventId}")]
        public IActionResult Banner(Guid? schooleventId)
        {
            return View(new BannerViewModel() { SchoolEventId = schooleventId });
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("/manage/schoolevents/update-banner")]
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
            var dirPath = _env.WebRootPath + "/images/schoolevents/" + model.SchoolEventId.ToString();
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
            return RedirectToAction("Banner", new { SchoolEventId = model.SchoolEventId });
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
    }
}