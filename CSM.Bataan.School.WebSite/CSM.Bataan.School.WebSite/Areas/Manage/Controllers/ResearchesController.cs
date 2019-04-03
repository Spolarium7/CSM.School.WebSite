using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Researches;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ResearchesController : Controller
    {

            private readonly DefaultDbContext _context;
            private IHostingEnvironment _env;


            public ResearchesController(DefaultDbContext context, IHostingEnvironment env)
            {
                _context = context;
                _env = env;
            }

            [Authorize(Policy = "AuthorizeAdmin")]
            [HttpGet, Route("manage/researches/index")]
            [HttpGet, Route("manage/researches")]
            public IActionResult Index(int pageIndex = 1, int pageSize = 10, string keyword = "")
            {

                Page<Research> result = new Page<Research>();
                if (pageSize < 1)
                {
                    pageSize = 1;
                }
                IQueryable<Research> resQuery = (IQueryable<Research>)this._context.Researches;
                if (string.IsNullOrEmpty(keyword) == false)
                {
                    resQuery = resQuery.Where(u => u.Title.ToLower().Contains(keyword.ToLower()));
                }
                long queryCount = resQuery.Count();

                int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
                long mod = (queryCount % pageSize);

                if (mod > 0)
                {
                    pageCount = pageCount + 1;
                }

                int skip = (int)(pageSize * (pageIndex - 1));
                List<Research> research = resQuery.ToList();

                result.Items = research.Skip(skip).Take((int)pageSize).ToList();
                result.PageCount = pageCount;
                result.PageSize = pageSize;
                result.QueryCount = queryCount;
                result.PageIndex = pageIndex;
                result.Keyword = keyword;


                return View(new IndexViewModel()
                {
                    Researches = result
                });
            }


        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("manage/researches/create")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/researches/create")]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            Research research = new Research()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Content = model.Content,
                Year = model.Year,
                PostExpiry = model.PostExpiry,
                IsPublished = true
               




            };
            this._context.Researches.Add(research);
            this._context.SaveChanges();
            return View();
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/researches/unpublish")]
        public IActionResult Unpublish(ResearchesIdViewModel model)
        {
            var research = this._context.Researches.FirstOrDefault(f => f.Id == model.Id);
            if (research != null)
            {
                research.IsPublished = false;
                this._context.Researches.Update(research);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/researches/publish")]
        public IActionResult Publish(ResearchesIdViewModel model)
        {
            var research = this._context.Researches.FirstOrDefault(f => f.Id == model.Id);

            if (research != null)
            {
                research.IsPublished = true;
                this._context.Researches.Update(research);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }



        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("manage/researches/update-title/{researchId}")]
        public IActionResult UpdateTitle(Guid? researchId)
        {
            var research = this._context.Researches.FirstOrDefault(f => f.Id == researchId);
            if (research != null)
            {
                return View(new UpdateTitleViewModel()
                {
                    Id = research.Id,
                    Title = research.Title,
                    PostExpiry = research.PostExpiry

                });
            }
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/researches/update-title")]
        public IActionResult UpdateQuestion(UpdateTitleViewModel model)
        {
            var research = this._context.Researches.FirstOrDefault(f => f.Id == model.Id);
            if (research != null)
            {
                research.Title = model.Title;
              
                research.PostExpiry = model.PostExpiry;
                research.Timestamp = DateTime.UtcNow;
                this._context.Researches.Update(research);
                this._context.SaveChanges();
            }
            return RedirectToAction("Index");
        }



        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("manage/researches/update-content/{researchId}")]
        public IActionResult UpdateContent(Guid? researchId)
        {
            var research = this._context.Researches.FirstOrDefault(f => f.Id == researchId);
            if (research != null)
            {
                return View(new UpdateContentViewModel()
                {
                    ResearchId = research.Id,
                    Title = research.Title,
                    Content = research.Content


                });
            }
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/researches/update-content")]
        public IActionResult UpdateContent(UpdateContentViewModel model)
        {
            var research = this._context.Researches.FirstOrDefault(f => f.Id == model.ResearchId);
            if (research != null)
            {

                research.Content = model.Content;
                research.Timestamp = DateTime.UtcNow;
                this._context.Researches.Update(research);
                this._context.SaveChanges();
            }
            return RedirectToAction("Index");
        }



        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("/manage/researches/attach-image")]
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

            var dirPath = _env.WebRootPath + "/images/researches/" + model.ResearchId.ToString();
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }


            var imgUrl = "/answer_" + Guid.NewGuid().ToString() + ".png";
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

            return "OK:/researches/" + model.ResearchId.ToString() + "/" + imgUrl;
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