using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Certifications;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    public class CertificationsController : Controller
    {
        private readonly DefaultDbContext _context;
        private IHostingEnvironment _env;

        public CertificationsController(DefaultDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [Authorize(Policy = "AuthorizeContentAdmin")]
        [HttpGet, Route("manage/certifications/index")]
        [HttpGet, Route("manage/certifications")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 2, string keyword = "")
        {
            Page<Certification> result = new Page<Certification>();

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IQueryable<Certification> certificationsQuery = (IQueryable<Certification>)this._context.Certifications;

            if (string.IsNullOrEmpty(keyword) == false)
            {
                certificationsQuery = certificationsQuery.Where(u => u.Title.ToLower().Contains(keyword.ToLower()));
            }

            long queryCount = certificationsQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<Certification> certifications = certificationsQuery.ToList();


            result.Items = certifications.Skip(skip).Take((int)pageSize).OrderByDescending(n => n.Timestamp).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;

            return View("~/Areas/Manage/Views/Certifications/Index.cshtml", new CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Certifications.IndexViewModel()
            {
                Certifications = result
            });
        }
    }
}