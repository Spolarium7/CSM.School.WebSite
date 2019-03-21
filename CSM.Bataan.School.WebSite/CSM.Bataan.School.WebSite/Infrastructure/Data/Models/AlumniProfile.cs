using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Infrastructure.Data.Models
{
    public class AlumniProfile : BaseModel
    {
        public string Position { get; set; }

        public string Company { get; set; }

        public string Location { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public bool IsPublished { get; set; }

        public string Description { get; set; }


    }
}
