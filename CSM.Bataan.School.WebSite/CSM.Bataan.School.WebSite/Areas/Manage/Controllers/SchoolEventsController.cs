using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.SchoolEvents;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SchoolEventsController : Controller
    {
        private readonly DefaultDbContext _context;
        private IHostingEnvironment _env;

        public SchoolEventsController(DefaultDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet, Route("manage/schoolevents/index")]
        [HttpGet, Route("manage/schoolevents")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 10, string keyword = "")
        {

            Page<SchoolEvent> result = new Page<SchoolEvent>();
            if (pageSize < 1)
            {
                pageSize = 1;
            }
            IQueryable<SchoolEvent> schooleveQuery = (IQueryable<SchoolEvent>)this._context.SchoolEvents;
            if (string.IsNullOrEmpty(keyword) == false)
            {
                schooleveQuery = schooleveQuery.Where(u => u.Title.ToLower().Contains(keyword.ToLower()));
            }
            long queryCount = schooleveQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<SchoolEvent> users = schooleveQuery.ToList();

            result.Items = users.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;


            return View(new IndexViewModel()
            {
                SchoolEvents = result
            });
        }

        [HttpGet, Route("manage/schoolevents/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("manage/schoolevents/create")]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            SchoolEvent schoolevent = new SchoolEvent()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                Content = model.Content,
                PostExpiry = model.PostExpiry,
                IsPublished = true,
                EventStart = model.EventStart,
                EventEnd = model.EventEnd




            };
            this._context.SchoolEvents.Add(schoolevent);
            this._context.SaveChanges();
            return View();
        }

        [HttpPost, Route("manage/schoolevents/unpublish")]
        public IActionResult Unpublish(SchoolEventIdViewModel model)
        {
            var schoolevent = this._context.SchoolEvents.FirstOrDefault(p => p.Id == model.Id);
            if (schoolevent != null)
            {
                schoolevent.IsPublished = false;
                this._context.SchoolEvents.Update(schoolevent);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }

        [HttpPost, Route("manage/schoolevents/publish")]
        public IActionResult Publish(SchoolEventIdViewModel model)
        {
            var schoolevent = this._context.SchoolEvents.FirstOrDefault(p => p.Id == model.Id);

            if (schoolevent != null)
            {
                schoolevent.IsPublished = true;
                this._context.SchoolEvents.Update(schoolevent);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }


        [HttpGet, Route("/manage/schoolevents/update-title/{schooleventId}")]
        public IActionResult UpdateTitle(Guid? schooleventId)
        {
            var schoolevent = this._context.SchoolEvents.FirstOrDefault(p => p.Id == schooleventId);
            if (schoolevent != null)
            {
                var model = new UpdateTitleViewModel()
                {
                    Id = schoolevent.Id,
                    Description = schoolevent.Description,
                    Title = schoolevent.Title,
                    PostExpiry = schoolevent.PostExpiry,
                    EventStart = schoolevent.EventStart,
                    EventEnd = schoolevent.EventEnd,
                

                };
                return View(model);
            }
            return RedirectToAction("Create");
        }

        [HttpPost, Route("/manage/schoolevents/update-title")]
        public IActionResult UpdateTitle(UpdateTitleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var schoolevent = this._context.SchoolEvents.FirstOrDefault(p => p.Id == model.Id);

            if (schoolevent != null)
            {
                schoolevent.Title = model.Title;
                schoolevent.Description = model.Description;
                schoolevent.PostExpiry = model.PostExpiry;
                schoolevent.EventStart = model.EventStart;
                schoolevent.EventEnd = model.EventEnd;

                this._context.SchoolEvents.Update(schoolevent);
                this._context.SaveChanges();
            }

            return RedirectToAction("Index");
        }



        [HttpGet, Route("/manage/schoolevents/update-content/{schooleventId}")]
        public IActionResult UpdateContent(Guid? schooleventId)
        {
            var schoolevent = this._context.SchoolEvents.FirstOrDefault(t => t.Id == schooleventId);
            if (schoolevent != null)
            {
                return View(new UpdateContentViewModel()
                {
                    SchoolEventId = schoolevent.Id,
                    Title = schoolevent.Title,
                    Content = schoolevent.Content

                });
            }
            return RedirectToAction("Index");
        }
        [HttpPost, Route("/manage/schoolevents/update-content/")]
        public IActionResult UpdateContent(UpdateContentViewModel model)
        {
            var schoolevent = this._context.SchoolEvents.FirstOrDefault(t => t.Id == model.SchoolEventId);
            if (schoolevent != null)
            {
                schoolevent.Content = model.Content;
                schoolevent.Timestamp = DateTime.UtcNow;

                this._context.SchoolEvents.Update(schoolevent);
                this._context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}