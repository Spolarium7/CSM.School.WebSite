using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeKicker.BBCode;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using CSM.Bataan.School.WebSite.ViewModels.Researches;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Controllers
{
    public class ResearchesController : Controller
    {
        private readonly DefaultDbContext _context;

        public ResearchesController(DefaultDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("researches")]
        [HttpGet, Route("researches/index")]
        public IActionResult Index()
        {
            return View(new IndexViewModel()
            {
                Researches = Feed(1)
            });
        }


        [HttpGet, Route("researches/feed")]
        public List<Research> Feed(int pageIndex)
        {
            int skip = (int)(3 * (pageIndex - 1));
            return this._context.Researches
                                .Where(p => p.IsPublished == true)
                                .OrderBy(p => p.Timestamp)
                                .Skip(skip)
                                .Take(30)
                                .ToList();
        }


        [HttpGet, Route("researches/{researchId}")]
        public IActionResult Research(Guid? researchId)
        {

            var research = this._context.Researches.FirstOrDefault(s => s.Id == researchId);
            if (research != null)
            {
                return View(new ResearchViewModel()
                {
                    ResearchId = research.Id,
                    Title = research.Title,
                    Content = ParseBBCode(research.Content)
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