using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.SchoolEvents
{
    public class UpdateContentViewModel
    {
        public Guid? SchoolEventId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}