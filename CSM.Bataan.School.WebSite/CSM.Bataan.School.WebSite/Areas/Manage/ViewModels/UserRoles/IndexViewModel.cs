using CSM.Bataan.School.WebSite.Infrastructure.Data.Enums;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.UserRoles
{
    public class IndexViewModel
    {
        public Guid? UserId { get; set; }

        public string UserName { get; set; }

        public Page<Role> Roles { get; set; }
    }
}
