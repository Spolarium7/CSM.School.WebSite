using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Courses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CoursesController : Controller
    {
        private readonly DefaultDbContext _context;
        private IHostingEnvironment _env;


        public CoursesController(DefaultDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet, Route("manage/courses/index")]
        [HttpGet, Route("manage/courses")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 2, string keyword = "")
        {

            Page<Course> result = new Page<Course>();
            if (pageSize < 1)
            {
                pageSize = 1;
            }
            IQueryable<Course> courseQuery = (IQueryable<Course>)this._context.Courses;
            if (string.IsNullOrEmpty(keyword) == false)
            {
                courseQuery = courseQuery.Where(u => u.Title.ToLower().Contains(keyword.ToLower()));
            }
            long queryCount = courseQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<Course> users = courseQuery.ToList();

            result.Items = users.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;


            return View(new IndexViewModel()
            {
                Courses = result
            });
        }

        [HttpGet, Route("manage/courses/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("manage/courses/create")]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            Course course = new Course()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Year = model.Year,
                CourseCode = model.CourseCode,
                Description = model.Description,
                Content = model.Content,
                PostExpiry = model.PostExpiry,
                IsPublished = true,
             




            };
            this._context.Courses.Add(course);
            this._context.SaveChanges();
            return View();
        }


        [HttpPost, Route("manage/courses/unpublish")]
        public IActionResult Unpublish(CoursesIdViewModel model)
        {
            var course = this._context.Courses.FirstOrDefault(p => p.Id == model.Id);
            if (course != null)
            {
                course.IsPublished = false;
                this._context.Courses.Update(course);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }

        [HttpPost, Route("manage/courses/publish")]
        public IActionResult Publish(CoursesIdViewModel model)
        {
            var course = this._context.Courses.FirstOrDefault(p => p.Id == model.Id);

            if (course != null)
            {
                course.IsPublished = true;
                this._context.Courses.Update(course);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }


    }
}