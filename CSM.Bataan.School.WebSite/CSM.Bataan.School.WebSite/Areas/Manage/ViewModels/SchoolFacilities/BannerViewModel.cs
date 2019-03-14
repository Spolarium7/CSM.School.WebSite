using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.SchoolFacilities
{
    public class BannerViewModel
    {
        public Guid? SchoolFacilityId { get; set; }

        public IFormFile Banner { get; set; }
    }
}