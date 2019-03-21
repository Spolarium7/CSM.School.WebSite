using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Infrastructure.Data.Models
{
    public class SchoolEvent : BaseModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Description { get; set; }

        public string TemplateName { get; set; }

        public bool IsPublished { get; set; }

        public DateTime PostExpiry { get; set; }

        public DateTime EventStart { get; set; }

        public DateTime EventEnd { get; set; }


    }
}
