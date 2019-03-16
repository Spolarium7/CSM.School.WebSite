using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Infrastructure.Data.Models
{
    public class NewsGroup : BaseModel
    {
        public Guid? NewsItemId { get; set; }

        public Guid? GroupId { get; set; }
    }
}
