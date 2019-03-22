using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Courses
{
    public class AttachImageViewModel
    {
        public Guid? CourseId { get; set; }
        public IFormFile Image { get; set; }
    }
}
