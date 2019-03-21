using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Faqs;
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
    public class FaqsController : Controller
    {
        private readonly DefaultDbContext _context;
        private IHostingEnvironment _env;


        public FaqsController(DefaultDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("manage/faqs/index")]
        [HttpGet, Route("manage/faqs")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 10, string keyword = "")
        {

            Page<Faq> result = new Page<Faq>();
            if (pageSize < 1)
            {
                pageSize = 1;
            }
            IQueryable<Faq> faqQuery = (IQueryable<Faq>)this._context.Faqs;
            if (string.IsNullOrEmpty(keyword) == false)
            {
                faqQuery = faqQuery.Where(u => u.Question.ToLower().Contains(keyword.ToLower()));
            }
            long queryCount = faqQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<Faq> users = faqQuery.ToList();

            result.Items = users.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;


            return View(new IndexViewModel()
            {
                Faqs = result
            });
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("manage/faqs/create")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/faqs/create")]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            Faq faq = new Faq()
            {
                Id = Guid.NewGuid(),
                Question = model.Question,
                Description = model.Description,
                Answer = model.Answer,
                PostExpiry = model.PostExpiry,
                IsPublished = true,
                TemplateName = "faq1"




            };
            this._context.Faqs.Add(faq);
            this._context.SaveChanges();
            return View();
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/faqs/unpublish")]
        public IActionResult Unpublish(FaqsIdViewModel model)
        {
            var faq = this._context.Faqs.FirstOrDefault(f => f.Id == model.Id);
            if (faq != null)
            {
                faq.IsPublished = false;
                this._context.Faqs.Update(faq);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/faqs/publish")]
        public IActionResult Publish(FaqsIdViewModel model)
        {
            var faq = this._context.Faqs.FirstOrDefault(f => f.Id == model.Id);

            if (faq != null)
            {
                faq.IsPublished = true;
                this._context.Faqs.Update(faq);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("/manage/faqs/delete/{faqId}")]
        public IActionResult Delete(Guid? faqId)
        {
            var faq = this._context.Faqs.FirstOrDefault(f => f.Id == faqId);
            if (faq != null)
            {

                this._context.Faqs.Remove(faq);
                this._context.SaveChanges();
            }
            return RedirectToAction("index");
        }


        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("manage/faqs/update-question/{faqId}")]
        public IActionResult UpdateQuestion(Guid? faqId)
        {
            var faq = this._context.Faqs.FirstOrDefault(f => f.Id == faqId);
            if (faq != null)
            {
                return View(new UpdateQuestionViewModel()
                {
                    Id = faq.Id,
                    Question = faq.Question,
                    Description = faq.Description,
                    TemplateName = faq.TemplateName,
                    PostExpiry = faq.PostExpiry

                });
            }
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/faqs/update-question")]
        public IActionResult UpdateQuestion(UpdateQuestionViewModel model)
        {
            var faq = this._context.Faqs.FirstOrDefault(f => f.Id == model.Id);
            if (faq != null)
            {
                faq.Question = model.Question;
                faq.Description = model.Description;
                faq.PostExpiry = model.PostExpiry;
                faq.Timestamp = DateTime.UtcNow;
                this._context.Faqs.Update(faq);
                this._context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("manage/faqs/update-content/{faqId}")]
        public IActionResult UpdateContent(Guid? faqId)
        {
            var faq = this._context.Faqs.FirstOrDefault(f => f.Id == faqId);
            if (faq != null)
            {
                return View(new UpdateContentViewModel()
                {
                    FaqId = faq.Id,
                    Answer = faq.Answer,
                    Question = faq.Question


                });
            }
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/faqs/update-content")]
        public IActionResult UpdateContent(UpdateContentViewModel model)
        {
            var faq = this._context.Faqs.FirstOrDefault(f => f.Id == model.FaqId);
            if (faq != null)
            {

                faq.Answer = model.Answer;
                faq.Timestamp = DateTime.UtcNow;
                this._context.Faqs.Update(faq);
                this._context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("/manage/faqs/attach-image")]
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

            var dirPath = _env.WebRootPath + "/faqs/" + model.FaqId.ToString();
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

            return "OK:/faqs/" + model.FaqId.ToString() + "/" + imgUrl;
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