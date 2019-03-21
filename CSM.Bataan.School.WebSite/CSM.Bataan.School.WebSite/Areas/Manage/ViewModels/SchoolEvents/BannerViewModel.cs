using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.SchoolEvents
{
    public class BannerViewModel
    {
        public Guid? SchoolEventId { get; set; }
        public IFormFile Banner { get; set; }
    }
}
