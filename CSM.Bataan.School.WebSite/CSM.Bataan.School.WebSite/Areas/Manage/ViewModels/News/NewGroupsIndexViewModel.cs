using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.News
{
    public class NewGroupsIndexViewModel
    {
        public Guid? NewsId { get; set; }

        public string NewsTitle { get; set; }

        public List<Group> Groups { get; set; }
    }
}
