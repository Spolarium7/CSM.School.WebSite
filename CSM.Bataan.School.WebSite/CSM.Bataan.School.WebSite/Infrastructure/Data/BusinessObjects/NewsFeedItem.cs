using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Infrastructure.Data.BusinessObjects
{
    public class NewsFeedItem : BaseModel
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsPublished { get; set; }

        public Guid? UserId { get; set; }

        public string UserName { get; set; }

        public List<string> Groups { get; set; }

        public DateTime PostExpiry { get; set; }
    }
}
