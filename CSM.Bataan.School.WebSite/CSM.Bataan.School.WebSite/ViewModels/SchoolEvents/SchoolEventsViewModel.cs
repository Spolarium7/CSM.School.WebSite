using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.ViewModels.SchoolEvents
{
    public class SchoolEventsViewModel
    {
        public Guid? SchoolEventId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PostExpiry { get; set; }

        public DateTime EventStart { get; set; }

        public DateTime EventEnd { get; set; }


    }
}
