using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Certifications;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Shared;
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
    public class CertificationsController : Controller
    {
        private readonly DefaultDbContext _context;
        private IHostingEnvironment _env;

        public CertificationsController(DefaultDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [Authorize(Policy = "AuthorizeContentAdmin")]
        [HttpGet, Route("manage/certifications/index")]
        [HttpGet, Route("manage/certifications")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 2, string keyword = "")
        {
            Page<Certification> result = new Page<Certification>();

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IQueryable<Certification> certificationsQuery = (IQueryable<Certification>)this._context.Certifications;

            if (string.IsNullOrEmpty(keyword) == false)
            {
                certificationsQuery = certificationsQuery.Where(u => u.Title.ToLower().Contains(keyword.ToLower()));
            }

            long queryCount = certificationsQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<Certification> certifications = certificationsQuery.ToList();


            result.Items = certifications.Skip(skip).Take((int)pageSize).OrderByDescending(n => n.Timestamp).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;

            return View("~/Areas/Manage/Views/Certifications/Index.cshtml", new CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Certifications.IndexViewModel()
            {
                Certifications = result
            });
        }

        [Authorize(Policy = "AuthorizeContentAdmin")]
        [HttpPost, Route("manage/certifications/update-{type}")]
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

            var dirPath = _env.WebRootPath + "/certifications/" + model.Id.ToString();
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
            return RedirectPermanent("~/manage/certifications?" + model.Filters);
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
        [HttpPost, Route("manage/certifications/update-publish-status")]
        public IActionResult UpdatePublishStatus(PublishUnpublishViewModel model)
        {
            var certification = this._context.Certifications.FirstOrDefault(n => n.Id == model.Id);

            if (certification != null)
            {
                certification.IsPublished = model.IsPublished;

                this._context.Certifications.Update(certification);

                this._context.SaveChanges();
            }

            return RedirectPermanent("~/manage/certifications?" + model.Filters);
        }
    }
}