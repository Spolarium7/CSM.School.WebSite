using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeKicker.BBCode;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.ViewModels.SchoolFacility;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Controllers
{
    public class SchoolFacilitiesController : Controller
    {
        private readonly DefaultDbContext _context;

        public SchoolFacilitiesController(DefaultDbContext context)
        {
            _context = context;
        }


        [HttpGet, Route("schoolfacilities")]
        [HttpGet, Route("schoolfacilities/index")]
        public IActionResult Index()
        {
            return View(new IndexViewModel()
            {
                SchoolFacilities = this._context.SchoolFacilities.ToList()
            });
        }

      

    }
}