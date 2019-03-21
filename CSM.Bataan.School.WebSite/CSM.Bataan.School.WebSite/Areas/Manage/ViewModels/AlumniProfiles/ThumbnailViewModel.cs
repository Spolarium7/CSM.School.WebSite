using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.AlumniProfiles
{
    public class ThumbnailViewModel
    {
        public Guid? AlumniProfileId { get; set; }

        public IFormFile Thumbnail { get; set; }
    }
}