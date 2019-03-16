using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.ViewModels.SchoolFacility
{
    public class SchoolFacilityViewModel
    {
        public Guid? SchoolFacilityId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
