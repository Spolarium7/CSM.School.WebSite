using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeKicker.BBCode;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using CSM.Bataan.School.WebSite.ViewModels.FAQ;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Controllers
{
    public class FaqsController : Controller
    {

        private readonly DefaultDbContext _context;

        public FaqsController(DefaultDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("faqs")]
        [HttpGet, Route("faqs/index")]
        public IActionResult Index()
        {
            return View(new IndexViewModel()
            {
                Faqs = Feed(1)
            });
        }


        [HttpGet, Route("faqs/feed")]
        public List<Faq> Feed(int pageIndex)
        {
            int skip = (int)(3 * (pageIndex - 1));
            return this._context.Faqs
                                .Where(p => p.IsPublished == true)
                                .OrderBy(p => p.Timestamp)
                                .Skip(skip)
                                .Take(30)
                                .ToList();
        }
        


    }
}