using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Shared
{
    public class CreateContentViewModel
    {
        public string Content { get; set; }

        public string Description { get; set; }

        public DateTime PostExpiry { get; set; }

        public string Title { get; set; }
    }
}
