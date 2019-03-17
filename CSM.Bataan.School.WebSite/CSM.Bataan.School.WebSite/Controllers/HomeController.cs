using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;

namespace CSM.Bataan.School.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly DefaultDbContext _context;

        public HomeController(DefaultDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }
    }
}
