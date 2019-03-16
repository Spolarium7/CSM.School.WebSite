using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Threads
{
    public class ThumbnailViewModel
    {
        public Guid? ThreadId { get; set; }
        public IFormFile Thumbnail { get; set; }
    }
}