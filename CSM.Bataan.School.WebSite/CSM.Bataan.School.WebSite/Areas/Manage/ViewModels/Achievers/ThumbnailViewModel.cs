using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Achievers
{
    public class ThumbnailViewModel
    {
        public Guid? AchieverId { get; set; }
        public IFormFile Thumbnail { get; set; }
    }
}