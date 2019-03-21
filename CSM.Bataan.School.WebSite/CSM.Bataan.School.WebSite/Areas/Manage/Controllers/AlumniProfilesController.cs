using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.AlumniProfiles;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AlumniProfilesController : Controller
    {

        private readonly DefaultDbContext _context;
        private IHostingEnvironment _env;

        public AlumniProfilesController(DefaultDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet, Route("manage/alumniprofiles/index")]
        [HttpGet, Route("manage/alumniprofiles")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 5, string keyword = "")
        {
            Page<AlumniProfile> result = new Page<AlumniProfile>();

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IQueryable<AlumniProfile> alumniprofQuery = (IQueryable<AlumniProfile>)this._context.AlumniProfiles;

            if (string.IsNullOrEmpty(keyword) == false)
            {
                alumniprofQuery = alumniprofQuery.Where(u => u.Company.ToLower().Contains(keyword.ToLower()));
            }

            long queryCount = alumniprofQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<AlumniProfile> users = alumniprofQuery.ToList();

            result.Items = users.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;

            return View(new IndexViewModel()
            {
                AlumniProfiles = result
            });
        }


        [HttpGet, Route("manage/alumniprofiles/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("manage/alumniprofiles/create")]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            AlumniProfile alumniprofile = new AlumniProfile()
            {
                Id = Guid.NewGuid(),
                Position = model.Position,
                Company = model.Company,
                Location = model.Location,
                Description = model.Description,
                FromDate = model.FromDate,
                ToDate = model.ToDate
            };

            this._context.AlumniProfiles.Add(alumniprofile);
            this._context.SaveChanges();

            return View();
        }


    }
}