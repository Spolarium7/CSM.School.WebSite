using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.SchoolFacilities
{
    public class UpdateContentViewModel
    {
        public Guid? SchoolFacilityId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}