using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeKicker.BBCode;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using CSM.Bataan.School.WebSite.ViewModels.SchoolEvents;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Controllers
{
    public class SchoolEventsController : Controller
    {
        private readonly DefaultDbContext _context;
        private IHostingEnvironment _env;

        public SchoolEventsController(DefaultDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet, Route("schoolevents")]
        [HttpGet, Route("schoolevents/index")]
        public IActionResult Index()
        {
            return View(new IndexViewModel()
            {
                SchoolEvents = Feed(1)
            });
        }


        [HttpGet, Route("schoolevents/feed")]
        public List<SchoolEvent> Feed(int pageIndex)
        {
            int skip = (int)(3 * (pageIndex - 1));
            return this._context.SchoolEvents
                                .Where(p => p.IsPublished == true)
                                .OrderByDescending(p => p.Timestamp)
                                .Skip(skip)
                                .Take(10)
                                .ToList();
        }
        [HttpGet, Route("schoolevents/{schooleventsId}")]
        public IActionResult SchoolEvent(Guid? schooleventsId)
        {
            var schoolevents = this._context.SchoolEvents.FirstOrDefault(p => p.Id == schooleventsId);

            if (schoolevents != null)
            {
                return View(new SchoolEventsViewModel()
                {
                    SchoolEventId = schoolevents.Id,
                    Title = schoolevents.Title,
                    Content = ParseBBCode(schoolevents.Content),
                    EventStart = schoolevents.EventStart,
                    EventEnd = schoolevents.EventEnd,

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