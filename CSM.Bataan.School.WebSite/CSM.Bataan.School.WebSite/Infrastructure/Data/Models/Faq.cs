using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Infrastructure.Data.Models
{
    public class Faq : BaseModel
    {
        public string Question { get; set; }

        public string Answer { get; set; }

        public string Description { get; set; }

        public string TemplateName { get; set; }

        public DateTime PostExpiry { get; set; }

        public bool IsPublished { get; set; }

    }
}
