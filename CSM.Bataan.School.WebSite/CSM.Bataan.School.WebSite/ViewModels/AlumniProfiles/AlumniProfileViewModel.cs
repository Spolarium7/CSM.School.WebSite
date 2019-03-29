using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.ViewModels.AlumniProfiles
{
    public class AlumniProfileViewModel
    {
        public List<AlumniProfile> AlumniProfiles { get; set; }

        public Guid? AlumniProfileId { get; set; }

        public string Company { get; set; }

        public string Description { get; set; }

        public string Position { get; set; }

        public string Location { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
    }
}