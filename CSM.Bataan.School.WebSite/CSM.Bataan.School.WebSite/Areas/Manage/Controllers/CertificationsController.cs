using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    public class CertificationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}