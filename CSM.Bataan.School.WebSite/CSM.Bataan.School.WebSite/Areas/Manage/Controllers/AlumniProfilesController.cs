using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.AlumniProfiles;
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
    [Area("Manage")]
    public class AlumniProfilesController : Controller
    {

        private readonly DefaultDbContext _context;
        private IHostingEnvironment _env;

        public AlumniProfilesController(DefaultDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("manage/alumniprofiles/index")]
        [HttpGet, Route("manage/alumniprofiles")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 5, string keyword = "")
        {
            Page<AlumniProfile> result = new Page<AlumniProfile>();

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IQueryable<AlumniProfile> alumniprofQuery = (IQueryable<AlumniProfile>)this._context.AlumniProfiles;

            if (string.IsNullOrEmpty(keyword) == false)
            {
                alumniprofQuery = alumniprofQuery.Where(u => u.Company.ToLower().Contains(keyword.ToLower()));
            }

            long queryCount = alumniprofQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<AlumniProfile> users = alumniprofQuery.ToList();

            result.Items = users.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;

            return View(new IndexViewModel()
            {
                AlumniProfiles = result
            });
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("manage/alumniprofiles/create")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/alumniprofiles/create")]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            AlumniProfile alumniprofile = new AlumniProfile()
            {
                Id = Guid.NewGuid(),
                Position = model.Position,
                Company = model.Company,
                Location = model.Location,
                Description = model.Description,
                FromDate = model.FromDate,
                ToDate = model.ToDate
            };

            this._context.AlumniProfiles.Add(alumniprofile);
            this._context.SaveChanges();

            return View();
        }


        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/alumniprofiles/unpublish")]
        public IActionResult Unpublish(AlumniProfileIdViewModel model)
        {
            var alumniprofile = this._context.AlumniProfiles.FirstOrDefault(p => p.Id == model.Id);
            if (alumniprofile != null)
            {
                alumniprofile.IsPublished = false;
                this._context.AlumniProfiles.Update(alumniprofile);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }
        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/alumniprofiles/publish")]
        public IActionResult Publish(AlumniProfileIdViewModel model)
        {
            var alumniprofile = this._context.AlumniProfiles.FirstOrDefault(a => a.Id == model.Id);
            if (alumniprofile != null)
            {
                alumniprofile.IsPublished = true;
                this._context.AlumniProfiles.Update(alumniprofile);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }


        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("/manage/alumniprofiles/update-title/{alumniprofileId}")]
        public IActionResult UpdateTitle(Guid? alumniprofileId)
        {
            var alumniprofile = this._context.AlumniProfiles.FirstOrDefault(a => a.Id == alumniprofileId);
            if (alumniprofile != null)
            {
                var model = new UpdateTitleViewModel()
                {
                    AlumniProfileId = alumniprofile.Id,
                    Company = alumniprofile.Company,
                    Position = alumniprofile.Position,
                    Location = alumniprofile.Location,
                    FromDate = alumniprofile.FromDate,
                    ToDate = alumniprofile.ToDate
                };
                return View(model);
            }
            return RedirectToAction("Create");
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("/manage/alumniprofiles/update-title")]
        public IActionResult UpdateTitle(UpdateTitleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var alumniprofile = this._context.AlumniProfiles.FirstOrDefault(a => a.Id == model.AlumniProfileId);
            if (alumniprofile != null)
            {
                alumniprofile.Company = model.Company;
                alumniprofile.FromDate = model.FromDate;
                alumniprofile.ToDate = model.ToDate;
                alumniprofile.Position = model.Position;
                alumniprofile.Location = model.Location;
                this._context.AlumniProfiles.Update(alumniprofile);
                this._context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("/manage/alumniprofiles/update-description/{alumniprofileId}")]
        public IActionResult UpdateDescription(Guid? alumniprofileId)
        {
            var alumniprofile = this._context.AlumniProfiles.FirstOrDefault(p => p.Id == alumniprofileId);
            if (alumniprofile != null)
            {
                return View(new UpdateDescriptionViewModel()
                {
                    AlumniProfileId = alumniprofile.Id,
                    Company = alumniprofile.Company,
                    Description = alumniprofile.Description
                });
            }
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("/manage/alumniprofiles/update-description/")]
        public IActionResult UpdateDescription(UpdateDescriptionViewModel model)
        {
            var alumniprofile = this._context.AlumniProfiles.FirstOrDefault(p => p.Id == model.AlumniProfileId);
            if (alumniprofile != null)
            {
                alumniprofile.Company = model.Company;
                alumniprofile.Description = model.Description;
                alumniprofile.Timestamp = DateTime.UtcNow;
                this._context.AlumniProfiles.Update(alumniprofile);
                this._context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("/manage/alumniprofiles/update-thumbnail/{alumniprofileId}")]
        public IActionResult Thumbnail(Guid? alumniprofileId)
        {
            return View(new ThumbnailViewModel() { AlumniProfileId = alumniprofileId });
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("/manage/alumniprofiles/update-thumbnail")]
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
            var dirPath = _env.WebRootPath + "/images/alumniprofiles/" + model.AlumniProfileId.ToString();
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
            return RedirectToAction("Thumbnail", new { AlumniProfileId = model.AlumniProfileId });

        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("/manage/alumniprofiles/attach-image")]
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
            var dirPath = _env.WebRootPath + "/images/alumniprofiles/" + model.AlumniProfileId.ToString();
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            var imgUrl = "/description_" + Guid.NewGuid().ToString() + ".png";
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
            return "OK:/alumniprofiles/" + model.AlumniProfileId.ToString() + "/" + imgUrl;
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