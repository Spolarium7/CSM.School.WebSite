using CSM.Bataan.School.WebSite.Infrastructure.Data.BusinessObjects;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.ViewModels.Home
{
    public class IndexViewModel
    {
        public List<NewsFeedItem> PublicNews { get; set; }

        public List<SchoolEvent> PublicEvents { get; set; }
    }

}
