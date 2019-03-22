using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Certifications
{
    public class UpdateViewModel
    {
        public Guid? Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PostExpiry { get; set; }

        public int Limit { get; set; }

        public string Filters { get; set; }
    }
}
