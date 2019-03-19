using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.ViewModels.Certifications;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using Microsoft.AspNetCore.Mvc;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;

namespace CSM.Bataan.School.WebSite.Controllers
{
    public class CertificationsController : Controller
    {

        private readonly DefaultDbContext _context;

        public CertificationsController(DefaultDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("certifications")]
        [HttpGet, Route("certifications/index")]
        public IActionResult Index(int pageSize = 5, int pageIndex = 1, string keyword = "")
        {
            Page<Certification> result = new Page<Certification>();

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IQueryable<Certification> certificationQuery = (IQueryable<Certification>)this._context.Certifications;

            if (string.IsNullOrEmpty(keyword) == false)
            {
                certificationQuery = certificationQuery.Where(c => c.Title.Contains(keyword)
                                            || c.Description.Contains(keyword));
            }

            long queryCount = certificationQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<Certification> certifications = certificationQuery.ToList();

            result.Items = certifications.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;

            return View(new IndexViewModel()
            {
                Certifications = result
            });
        }
    }
}