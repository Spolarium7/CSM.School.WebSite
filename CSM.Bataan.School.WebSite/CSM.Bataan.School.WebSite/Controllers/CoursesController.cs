using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeKicker.BBCode;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using CSM.Bataan.School.WebSite.ViewModels.Courses;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Controllers
{
    public class CoursesController : Controller
    {
        private readonly DefaultDbContext _context;

        public CoursesController(DefaultDbContext context)
        {
            _context = context;
        }



        [HttpGet, Route("courses")]
        [HttpGet, Route("courses/index")]
        public IActionResult Index()
        {
            return View(new IndexViewModel()
            {
                Courses = Feed(1)
            });
        }



        [HttpGet, Route("courses/feed")]
        public List<Course> Feed(int pageIndex)
        {
            int skip = (int)(3 * (pageIndex - 1));
            return this._context.Courses
                                .Where(p => p.IsPublished == true)
                                .OrderBy(p => p.Timestamp)
                                .Skip(skip)
                                .Take(10)
                                .ToList();
        }


        [HttpGet, Route("courses/{courseId}")]
        public IActionResult Course(Guid? courseId)
        {
            var course = this._context.Courses.FirstOrDefault(p => p.Id == courseId);

            if (course != null)
            {
                return View(new CoursesViewModel()
                {
                    CourseId = course.Id,
                    Title = course.Title,
                    Year = course.Year,
                    CourseCode = course.CourseCode,
                    Content = ParseBBCode(course.Content)
                    
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