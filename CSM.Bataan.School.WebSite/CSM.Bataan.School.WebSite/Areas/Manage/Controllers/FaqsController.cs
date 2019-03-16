﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Faqs;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

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


        [HttpGet, Route("manage/faqs/create")]
        public IActionResult Create()
        {
            return View();
        }

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
                    TemplateName = faq.TemplateName,
                    PostExpiry = faq.PostExpiry

                });
            }
            return RedirectToAction("Index");
        }
        [HttpPost, Route("manage/faqs/update-question")]
        public IActionResult UpdateQuestion(UpdateQuestionViewModel model)
        {
            var faq = this._context.Faqs.FirstOrDefault(f => f.Id == model.Id);
            if (faq != null)
            {
                faq.Question = model.Question;
                faq.PostExpiry = model.PostExpiry;
                faq.Timestamp = DateTime.UtcNow;
                this._context.Faqs.Update(faq);
                this._context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}