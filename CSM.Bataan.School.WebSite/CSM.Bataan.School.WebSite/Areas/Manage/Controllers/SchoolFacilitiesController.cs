using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.SchoolFacilities;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SchoolFacilitiesController : Controller
    {
        private readonly DefaultDbContext _context;
        private IHostingEnvironment _env;

        public SchoolFacilitiesController(DefaultDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet, Route("manage/schoolfacilities/index")]
        [HttpGet, Route("manage/schoolfacilities")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 2, string keyword = "")
        {
            Page<SchoolFacility> result = new Page<SchoolFacility>();

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IQueryable<SchoolFacility> schoolfacilityQuery = (IQueryable<SchoolFacility>)this._context.SchoolFacilities;

            if (string.IsNullOrEmpty(keyword) == false)
            {
                schoolfacilityQuery = schoolfacilityQuery.Where(u => u.Title.ToLower().Contains(keyword.ToLower()));
            }

            long queryCount = schoolfacilityQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<SchoolFacility> schoolfacilities = schoolfacilityQuery.ToList();

            result.Items = schoolfacilities.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;

            return View(new IndexViewModel()
            {
                SchoolFacilities = result
            });
        }


        [HttpGet, Route("manage/schoolfacilities/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("manage/schoolfacilities/create")]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            SchoolFacility schoolfacilities = new SchoolFacility()
            {
                Id = Guid.NewGuid(),
                Content = model.Content,
                Description = model.Description,
                IsPublished = true,
                PostExpiry = model.PostExpiry,
                TemplateName = "schoolfacility1",
                Title = model.Title
            };

            this._context.SchoolFacilities.Add(schoolfacilities);
            this._context.SaveChanges();

            return View();
        }

        [HttpPost, Route("manage/schoolfacilities/unpublish")]
        public IActionResult Unpublish(SchoolFacilityIdViewModel model)
        {
            var schoolfacility = this._context.SchoolFacilities.FirstOrDefault(p => p.Id == model.Id);

            if (schoolfacility != null)
            {
                schoolfacility.IsPublished = false;
                this._context.SchoolFacilities.Update(schoolfacility);
                this._context.SaveChanges();
                return Ok();
            }

            return null;
        }

        [HttpPost, Route("manage/schoolfacilities/publish")]
        public IActionResult Publish(SchoolFacilityIdViewModel model)
        {
            var schoolfacility = this._context.SchoolFacilities.FirstOrDefault(p => p.Id == model.Id);

            if (schoolfacility != null)
            {
                schoolfacility.IsPublished = true;
                this._context.SchoolFacilities.Update(schoolfacility);
                this._context.SaveChanges();
                return Ok();
            }

            return null;
        }

        [HttpGet, Route("/manage/schoolfacilities/update-title/{schoolfacilityId}")]
        public IActionResult UpdateTitle(Guid? schoolfacilityId)
        {
            var schoolfacility = this._context.SchoolFacilities.FirstOrDefault(p => p.Id == schoolfacilityId);

            if (schoolfacility != null)
            {
                var model = new UpdateTitleViewModel()
                {
                    Id = schoolfacility.Id,
                    Description = schoolfacility.Description,
                    Title = schoolfacility.Title,
                    PostExpiry = schoolfacility.PostExpiry,
                    TemplateName = schoolfacility.TemplateName
                };

                return View(model);
            }

            return RedirectToAction("Create");
        }

        [HttpPost, Route("/manage/schoolfacilities/update-title")]
        public IActionResult UpdateTitle(UpdateTitleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var schoolfacility = this._context.SchoolFacilities.FirstOrDefault(p => p.Id == model.Id);

            if (schoolfacility != null)
            {
                schoolfacility.Title = model.Title;
                schoolfacility.Description = model.Description;
                schoolfacility.PostExpiry = model.PostExpiry;
                schoolfacility.TemplateName = model.TemplateName;

                this._context.SchoolFacilities.Update(schoolfacility);
                this._context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet, Route("/manage/schoolfacilities/update-content/{schoolfacilityId}")]
        public IActionResult UpdateContent(Guid? schoolfacilityId)
        {
            var schoolfacility = this._context.SchoolFacilities.FirstOrDefault(p => p.Id == schoolfacilityId);
            if (schoolfacility != null)
            {
                return View(new UpdateContentViewModel()
                {
                    SchoolFacilityId = schoolfacility.Id,
                    Title = schoolfacility.Title,
                    Content = schoolfacility.Content
                });
            }
            return RedirectToAction("Index");
        }
        [HttpPost, Route("/manage/schoolfacilities/update-content/")]
        public IActionResult UpdateContent(UpdateContentViewModel model)
        {
            var schoolfacility = this._context.SchoolFacilities.FirstOrDefault(p => p.Id == model.SchoolFacilityId);
            if (schoolfacility != null)
            {
                schoolfacility.Content = model.Content;
                schoolfacility.Timestamp = DateTime.UtcNow;
                this._context.SchoolFacilities.Update(schoolfacility);
                this._context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpPost, Route("/manage/schoolfacilities/attach-image")]
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
            var dirPath = _env.WebRootPath + "/schoolfacilities/" + model.SchoolFacilityId.ToString();
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
            return "OK:/schoolfacilities/" + model.SchoolFacilityId.ToString() + "/" + imgUrl;
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

        [HttpGet, Route("/manage/schoolfacilities/update-thumbnail/{schoolfacilityId}")]
        public IActionResult Thumbnail(Guid? schoolfacilityId)
        {
            return View(new ThumbnailViewModel() { SchoolFacilityId = schoolfacilityId });
        }
        [HttpPost, Route("/manage/schoolfacilities/update-thumbnail")]
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
            var dirPath = _env.WebRootPath + "/schoolfacilities/" + model.SchoolFacilityId.ToString();
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
            return RedirectToAction("Thumbnail", new { SchoolFacilityId = model.SchoolFacilityId });
        }


        [HttpGet, Route("/manage/schoolfacilities/update-banner/{schoolfacilityId}")]
        public IActionResult Banner(Guid? schoolfacilityId)
        {
            return View(new BannerViewModel() { SchoolFacilityId = schoolfacilityId });
        }
        [HttpPost, Route("/manage/schoolfacilities/update-banner")]
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
            var dirPath = _env.WebRootPath + "/schoolfacilities/" + model.SchoolFacilityId.ToString();
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
            return RedirectToAction("Banner", new { SchoolFacilityId = model.SchoolFacilityId });
        }



    }
}