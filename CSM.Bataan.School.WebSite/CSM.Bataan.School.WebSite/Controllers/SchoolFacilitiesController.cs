using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeKicker.BBCode;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using CSM.Bataan.School.WebSite.ViewModels.SchoolFacility;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Controllers
{
    public class SchoolFacilitiesController : Controller
    {
        private readonly DefaultDbContext _context;

        public SchoolFacilitiesController(DefaultDbContext context)
        {
            _context = context;
        }


        [HttpGet, Route("schoolfacilities")]
        [HttpGet, Route("schoolfacilities/index")]
        public IActionResult Index()
        {
            return View(new IndexViewModel()
            {
                SchoolFacilities = this._context.SchoolFacilities.ToList()
            });
        }
        [HttpGet, Route("schoolfacilities/feed")]
        public List<SchoolFacility> Feed(int pageIndex)
        {
            int skip = (int)(3 * (pageIndex - 1));
            return this._context.SchoolFacilities
                                .Where(p => p.IsPublished == true)
                                .OrderBy(p => p.Timestamp)
                                .Skip(skip)
                                .Take(30)
                                .ToList();
        }


        [HttpGet, Route("schoolfacilities/{schoolfacilityId}")]
        public IActionResult SchoolFacility(Guid? schoolfacilityId)
        {

            var schoolfacility = this._context.SchoolFacilities.FirstOrDefault(s => s.Id == schoolfacilityId);
            if (schoolfacility != null)
            {
                return View(new SchoolFacilityViewModel()
                {
                    SchoolFacilityId = schoolfacility.Id,
                    Title = schoolfacility.Title,
                    Content = ParseBBCode(schoolfacility.Content)
                });
            }
            return StatusCode(404);
        }


        public string ParseBBCode(string bbcode)
        {
            var parser = new BBCodeParser(new[]
                {
                    new BBTag("img", "<img src=\"${content}\" />", "", false, true),
                    new BBTag("b", "<strong>", "</strong>"),
                    new BBTag("color","<font  color=\"${color}\">","</font >", new BBAttribute("color", ""), new BBAttribute("color", "color")),
                    new BBTag("i", "<span style=\"font-style:italic;\">", "</span>"),
                    new BBTag("u", "<span style=\"text-decoration:underline;\">", "</span>"),
                    new BBTag("code", "<pre class=\"prettyprint\">", "</pre>"),
                    new BBTag("quote", "<blockquote>", "</blockquote>"),
                    new BBTag("list", "<ul>", "</ul>"),
                    new BBTag("*", "<li>", "</li>", true, false),
                    new BBTag("url", "<a href=\"${href}\">", "</a>", new BBAttribute("href", ""), new BBAttribute("href", "href")),
                    new BBTag("youtube", "<div class='video'><iframe width='550px' height='309px' src='//www.youtube.com/embed/${content}' allowFullScreen></iframe></div>","", false, true),
                });
            return parser.ToHtml(bbcode);
        }


    }
}