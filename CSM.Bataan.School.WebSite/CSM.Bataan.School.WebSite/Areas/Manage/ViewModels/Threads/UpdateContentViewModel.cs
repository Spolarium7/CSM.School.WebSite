using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Threads
{
    public class UpdateContentViewModel
    {
        public Guid? ThreadId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}