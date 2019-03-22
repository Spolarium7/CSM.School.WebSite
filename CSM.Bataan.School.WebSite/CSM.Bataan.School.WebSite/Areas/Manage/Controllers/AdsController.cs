using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Ads;
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
    public class AdsController : Controller
    {
        private readonly DefaultDbContext _context;
        private IHostingEnvironment _env;


        public AdsController(DefaultDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet, Route("manage/ads/index")]
        [HttpGet, Route("manage/ads")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 2, string keyword = "")
        {

            Page<Ad> result = new Page<Ad>();
            if (pageSize < 1)
            {
                pageSize = 1;
            }
            IQueryable<Ad> adQuery = (IQueryable<Ad>)this._context.Ads;
            if (string.IsNullOrEmpty(keyword) == false)
            {
                adQuery = adQuery.Where(u => u.Title.ToLower().Contains(keyword.ToLower()));
            }
            long queryCount = adQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<Ad> users = adQuery.ToList();

            result.Items = users.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;


            return View(new IndexViewModel()
            {
                Ads = result
            });
        }

        [HttpGet, Route("manage/ads/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("manage/ads/create")]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            Ad ad = new Ad()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                Content = model.Content,
                PostExpiry = model.PostExpiry,
                IsPublished = true,
              




            };
            this._context.Ads.Add(ad);
            this._context.SaveChanges();
            return View();
        }

        [HttpPost, Route("manage/ads/unpublish")]
        public IActionResult Unpublish(AdIdViewModel model)
        {
            var ad = this._context.Ads.FirstOrDefault(p => p.Id == model.Id);
            if (ad != null)
            {
                ad.IsPublished = false;
                this._context.Ads.Update(ad);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }

        [HttpPost, Route("manage/ads/publish")]
        public IActionResult Publish(AdIdViewModel model)
        {
            var ad = this._context.Ads.FirstOrDefault(p => p.Id == model.Id);

            if (ad != null)
            {
                ad.IsPublished = true;
                this._context.Ads.Update(ad);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }


        [HttpGet, Route("/manage/ads/update-title/{adId}")]
        public IActionResult UpdateTitle(Guid? adId)
        {
            var ad = this._context.Ads.FirstOrDefault(p => p.Id == adId);
            if (ad != null)
            {
                var model = new UpdateTitleViewModel()
                {
                    Id = ad.Id,
                    Description = ad.Description,
                    Title = ad.Title,
                    PostExpiry = ad.PostExpiry,
                  

                };
                return View(model);
            }
            return RedirectToAction("Create");
        }

        [HttpPost, Route("/manage/ads/update-title")]
        public IActionResult UpdateTitle(UpdateTitleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var ad = this._context.Ads.FirstOrDefault(p => p.Id == model.Id);

            if (ad != null)
            {
                ad.Title = model.Title;
                ad.Description = model.Description;
                ad.PostExpiry = model.PostExpiry;
              

                this._context.Ads.Update(ad);
                this._context.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        [HttpGet, Route("/manage/ads/update-content/{adId}")]
        public IActionResult UpdateContent(Guid? adId)
        {
            var ad = this._context.Ads.FirstOrDefault(t => t.Id == adId);
            if (ad != null)
            {
                return View(new UpdateContentViewModel()
                {
                    AdId = ad.Id,
                    Title = ad.Title,
                    Content = ad.Content
                });
            }
            return RedirectToAction("Index");
        }
        [HttpPost, Route("/manage/ads/update-content/")]
        public IActionResult UpdateContent(UpdateContentViewModel model)
        {
            var ad = this._context.Ads.FirstOrDefault(t => t.Id == model.AdId);
            if (ad != null)
            {
                ad.Content = model.Content;
                ad.Timestamp = DateTime.UtcNow;
                this._context.Ads.Update(ad);
                this._context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpPost, Route("/manage/ads/attach-image")]
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
            var dirPath = _env.WebRootPath + "/images/ads/" + model.AdId.ToString();
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
            return "OK:/ads/" + model.AdId.ToString() + "/" + imgUrl;
        }

        private Task<byte[]> FileBytes(Stream stream)
        {
            throw new NotImplementedException();
        }


        [HttpGet, Route("/manage/ads/update-banner/{adId}")]
        public IActionResult Banner(Guid? adId)
        {
            return View(new BannerViewModel() { AdId = adId });
        }
        [HttpPost, Route("/manage/ads/update-banner")]
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
            var dirPath = _env.WebRootPath + "/images/ads/" + model.AdId.ToString();
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
            return RedirectToAction("Banner", new { AdId = model.AdId });
        }




        [HttpGet, Route("/manage/ads/update-thumbnail/{adId}")]
        public IActionResult Thumbnail(Guid? adId)
        {
            return View(new ThumbnailViewModel() { AdId = adId });
        }
        [HttpPost, Route("/manage/ads/update-thumbnail")]
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
            var dirPath = _env.WebRootPath + "/images/ads/" + model.AdId.ToString();
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
            return RedirectToAction("Thumbnail", new { AdId = model.AdId });
        }
        
    }
}