using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.SchoolFacilities
{
    public class IndexViewModel
    {
        public Page<SchoolFacility> SchoolFacilities { get; set; }
    }
}