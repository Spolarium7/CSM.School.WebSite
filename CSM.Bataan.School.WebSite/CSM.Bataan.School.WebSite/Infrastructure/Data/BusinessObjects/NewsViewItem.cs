using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Infrastructure.Data.BusinessObjects
{
    public class NewsViewItem : NewsItem
    {
        public string UserName { get; set; }

        public List<string> Groups { get; set; }
    }
}
