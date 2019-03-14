using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.SchoolFacilities;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SchoolFacilitiesController : Controller
    {
        private readonly DefaultDbContext _context;
        private IHostingEnvironment _env;

        public SchoolFacilitiesController(DefaultDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet, Route("manage/schoolfacilities/index")]
        [HttpGet, Route("manage/schoolfacilities")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 2, string keyword = "")
        {
            Page<SchoolFacility> result = new Page<SchoolFacility>();

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IQueryable<SchoolFacility> schoolfacilityQuery = (IQueryable<SchoolFacility>)this._context.SchoolFacilities;

            if (string.IsNullOrEmpty(keyword) == false)
            {
                schoolfacilityQuery = schoolfacilityQuery.Where(u => u.Title.ToLower().Contains(keyword.ToLower()));
            }

            long queryCount = schoolfacilityQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<SchoolFacility> schoolfacilities = schoolfacilityQuery.ToList();

            result.Items = schoolfacilities.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;

            return View(new IndexViewModel()
            {
                SchoolFacilities = result
            });
        }


        [HttpGet, Route("manage/schoolfacilities/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("manage/schoolfacilities/create")]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            SchoolFacility schoolfacilities = new SchoolFacility()
            {
                Id = Guid.NewGuid(),
                Content = model.Content,
                Description = model.Description,
                IsPublished = true,
                PostExpiry = model.PostExpiry,
                TemplateName = "schoolfacility1",
                Title = model.Title
            };

            this._context.SchoolFacilities.Add(schoolfacilities);
            this._context.SaveChanges();

            return View();
        }

        [HttpPost, Route("manage/schoolfacilities/unpublish")]
        public IActionResult Unpublish(SchoolFacilityIdViewModel model)
        {
            var schoolfacility = this._context.SchoolFacilities.FirstOrDefault(p => p.Id == model.Id);

            if (schoolfacility != null)
            {
                schoolfacility.IsPublished = false;
                this._context.SchoolFacilities.Update(schoolfacility);
                this._context.SaveChanges();
                return Ok();
            }

            return null;
        }

        [HttpPost, Route("manage/schoolfacilities/publish")]
        public IActionResult Publish(SchoolFacilityIdViewModel model)
        {
            var schoolfacility = this._context.SchoolFacilities.FirstOrDefault(p => p.Id == model.Id);

            if (schoolfacility != null)
            {
                schoolfacility.IsPublished = true;
                this._context.SchoolFacilities.Update(schoolfacility);
                this._context.SaveChanges();
                return Ok();
            }

            return null;
        }

        [HttpGet, Route("/manage/schoolfacilities/update-title/{schoolfacilityId}")]
        public IActionResult UpdateTitle(Guid? schoolfacilityId)
        {
            var schoolfacility = this._context.SchoolFacilities.FirstOrDefault(p => p.Id == schoolfacilityId);

            if (schoolfacility != null)
            {
                var model = new UpdateTitleViewModel()
                {
                    Id = schoolfacility.Id,
                    Description = schoolfacility.Description,
                    Title = schoolfacility.Title,
                    PostExpiry = schoolfacility.PostExpiry,
                    TemplateName = schoolfacility.TemplateName
                };

                return View(model);
            }

            return RedirectToAction("Create");
        }

        [HttpPost, Route("/manage/schoolfacilities/update-title")]
        public IActionResult UpdateTitle(UpdateTitleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var schoolfacility = this._context.SchoolFacilities.FirstOrDefault(p => p.Id == model.Id);

            if (schoolfacility != null)
            {
                schoolfacility.Title = model.Title;
                schoolfacility.Description = model.Description;
                schoolfacility.PostExpiry = model.PostExpiry;
                schoolfacility.TemplateName = model.TemplateName;

                this._context.SchoolFacilities.Update(schoolfacility);
                this._context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet, Route("/manage/schoolfacilities/update-content/{schoolfacilityId}")]
        public IActionResult UpdateContent(Guid? schoolfacilityId)
        {
            var schoolfacility = this._context.SchoolFacilities.FirstOrDefault(p => p.Id == schoolfacilityId);
            if (schoolfacility != null)
            {
                return View(new UpdateContentViewModel()
                {
                    SchoolFacilityId = schoolfacility.Id,
                    Title = schoolfacility.Title,
                    Content = schoolfacility.Content
                });
            }
            return RedirectToAction("Index");
        }
        [HttpPost, Route("/manage/schoolfacilities/update-content/")]
        public IActionResult UpdateContent(UpdateContentViewModel model)
        {
            var schoolfacility = this._context.SchoolFacilities.FirstOrDefault(p => p.Id == model.SchoolFacilityId);
            if (schoolfacility != null)
            {
                schoolfacility.Content = model.Content;
                schoolfacility.Timestamp = DateTime.UtcNow;
                this._context.SchoolFacilities.Update(schoolfacility);
                this._context.SaveChanges();
            }
            return RedirectToAction("Index");
        }



    }
}