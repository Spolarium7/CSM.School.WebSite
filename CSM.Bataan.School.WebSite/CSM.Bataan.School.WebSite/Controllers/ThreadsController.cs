using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using CSM.Bataan.School.WebSite.ViewModels.Thread;
using CodeKicker.BBCode;

namespace CSM.Bataan.School.WebSite.Controllers
{
    public class ThreadsController : Controller
    {
        private readonly DefaultDbContext _context;

        public ThreadsController(DefaultDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("threads")]
        [HttpGet, Route("threads/index")]
        public IActionResult Index()
        {
            return View(new IndexViewModel()
            {
                Threads = Feed(1)
            });
        }

        [HttpGet, Route("threads/feed")]
        public List<Thread> Feed(int pageIndex)
        {
            int skip = (int)(3 * (pageIndex - 1));
            return this._context.Threads
                                .Where(p => p.IsPublished == true)
                                .OrderByDescending(p => p.Timestamp)
                                .Skip(skip)
                                .Take(10)
                                .ToList();
        }


        [HttpGet, Route("threads/{threadId}")]
        public IActionResult Threads(Guid? threadId)
        {
            var thread = this._context.Threads.FirstOrDefault(p => p.Id == threadId);
            if (thread != null)
            {
                return View(new ThreadViewModel()
                {
                    ThreadId = thread.Id,
                    Title = thread.Title,
                    Content = ParseBBCode(thread.Content)
               


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