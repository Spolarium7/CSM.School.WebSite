using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Ads
{
    public class AttachImageViewModel
    {
        public Guid? AdId { get; set; }
        public IFormFile Image { get; set; }
    }
}
