using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Infrastructure.Data.BusinessObjects
{
    public class FaqsFeedItem : BaseModel
    {
        public List<Faq> Faqs { get; set; }

        public Guid? FaqId { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public string Description { get; set; }

        public string TemplateName { get; set; }

        public DateTime PostExpiry { get; set; }

        public bool IsPublished { get; set; }
    }
}

 