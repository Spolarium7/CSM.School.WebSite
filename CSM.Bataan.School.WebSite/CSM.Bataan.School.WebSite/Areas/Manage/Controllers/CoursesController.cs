using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Courses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

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



        [HttpGet, Route("/manage/courses/update-title/{courseId}")]
        public IActionResult UpdateTitle(Guid? courseId)
        {
            var course = this._context.Courses.FirstOrDefault(p => p.Id == courseId);
            if (course != null)
            {
                var model = new UpdateTitleViewModel()
                {
                    Id = course.Id,
                    Description = course.Description,
                    Title = course.Title,
                    PostExpiry = course.PostExpiry
                

                };
                return View(model);
            }
            return RedirectToAction("Create");
        }

        [HttpPost, Route("/manage/courses/update-title")]
        public IActionResult UpdateTitle(UpdateTitleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var course = this._context.Courses.FirstOrDefault(p => p.Id == model.Id);

            if (course != null)
            {
                course.Title = model.Title;
                course.Description = model.Description;
                course.PostExpiry = model.PostExpiry;
           

                this._context.Courses.Update(course);
                this._context.SaveChanges();
            }

            return RedirectToAction("Index");
        }



        [HttpGet, Route("/manage/courses/update-content/{coursesId}")]
        public IActionResult UpdateContent(Guid? coursesId)
        {
            var course = this._context.Courses.FirstOrDefault(p => p.Id == coursesId);

            if (course != null)
            {
                return View(new UpdateContentViewModel()
                {
                    CourseId = course.Id,
                    Title = course.Title,
                    Content = course.Content
                });
            }

            return RedirectToAction("Index");
        }

        [HttpPost, Route("/manage/courses/update-content/")]
        public IActionResult UpdateContent(UpdateContentViewModel model)
        {
            var course = this._context.Courses.FirstOrDefault(p => p.Id == model.CourseId);

            if (course != null)
            {
                course.Content = model.Content;
                course.Timestamp = DateTime.UtcNow;

                this._context.Courses.Update(course);
                this._context.SaveChanges();
            }

            return RedirectToAction("Index");
        }



        [HttpGet, Route("/manage/courses/update-yearcoursecode/{coursesId}")]
        public IActionResult UpdateYearCourseCode(Guid? coursesId)
        {
            var course = this._context.Courses.FirstOrDefault(p => p.Id == coursesId);

            if (course != null)
            {
                return View(new UpdateYearCourseCodeViewModel()
                {
                    CourseId = course.Id,
                    Year = course.Year,
                    CourseCode = course.CourseCode
                });
            }

            return RedirectToAction("Index");
        }

        [HttpPost, Route("/manage/courses/update-yearcoursecode/")]
        public IActionResult UpdateYearCourseCode(UpdateYearCourseCodeViewModel model)
        {
            var course = this._context.Courses.FirstOrDefault(p => p.Id == model.CourseId);

            if (course != null)
            {
                course.Year = model.Year;
                course.CourseCode = model.CourseCode;
                course.Timestamp = DateTime.UtcNow;

                this._context.Courses.Update(course);
                this._context.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        [HttpPost, Route("/manage/courses/attach-image")]
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
            var dirPath = _env.WebRootPath + "/images/courses/" + model.CourseId.ToString();
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            var imgUrl = "/content_" + Guid.NewGuid().ToString() + ".png";
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
            return "OK:/courses/" + model.CourseId.ToString() + "/" + imgUrl;
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