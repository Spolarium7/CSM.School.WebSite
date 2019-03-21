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
    }
}