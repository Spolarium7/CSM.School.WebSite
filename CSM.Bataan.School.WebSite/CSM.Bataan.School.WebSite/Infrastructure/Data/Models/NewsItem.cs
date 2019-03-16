using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Infrastructure.Data.Models
{
    public class NewsItem : BaseModel
    {
        public string Title { get; set; }

        public Guid? UserId { get; set; }

        public string Content { get; set; }

        public bool IsPublished { get; set; }

        public string Description { get; set; }

        public DateTime PostExpiry { get; set; }
    }
}
