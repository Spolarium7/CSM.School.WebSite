using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.UserGroups
{
    public class GroupsIndexViewModel
    {
        public Guid? UserId { get; set; }

        public string UserName { get; set; }

        public Page<Group> Groups { get; set; }
    }
}
