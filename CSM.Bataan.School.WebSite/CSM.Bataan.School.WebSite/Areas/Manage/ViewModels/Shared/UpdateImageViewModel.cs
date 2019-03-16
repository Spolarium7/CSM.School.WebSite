using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Shared
{
    public class UpdateImageViewModel
    {
        public Guid? Id { get; set; }

        public IFormFile ImageFile { get; set; }

        public string Filters { get; set; }
    }
}
