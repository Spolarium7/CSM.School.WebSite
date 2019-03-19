using CSM.Bataan.School.WebSite.Infrastructure.Data.Enums;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Infrastructure.Data.Models
{
    public class Certification : BaseModel
    {
        public string Title { get; set; }

        public bool IsPublished { get; set; }

        public string Description { get; set; }

        public DateTime PostExpiry { get; set; }

        public int Limit { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public CertType Type { get; set; }
    }
}
