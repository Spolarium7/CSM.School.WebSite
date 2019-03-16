using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Shared
{
    public class PublishUnpublishViewModel
    {
        public Guid? Id { get; set; }

        public bool IsPublished { get; set; }

        public string Filters { get; set; }
    }
}
