using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.UserRoles
{
    public class AddRemoveUserRoleViewModel
    {
        public Guid? UserId { get; set; }

        public string Role { get; set; }
    }
}
