using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.ViewModels.Ads
{
    public class AdsViewModel
    {
        public Guid? AdId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PostExpiry { get; set; }

        public bool IsPublished { get; set; }

    }
}