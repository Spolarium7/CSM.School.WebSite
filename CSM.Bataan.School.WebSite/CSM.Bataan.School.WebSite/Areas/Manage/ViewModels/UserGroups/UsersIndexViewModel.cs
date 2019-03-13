using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.UserGroups
{
    public class UsersIndexViewModel
    {
        public Guid? GroupId { get; set; }

        public string GroupName { get; set; }

        public Page<User> Users { get; set; }
    }
}
