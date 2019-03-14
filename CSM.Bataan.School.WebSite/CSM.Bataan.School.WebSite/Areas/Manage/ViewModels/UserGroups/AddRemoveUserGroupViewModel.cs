using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.UserGroups
{
    public class AddRemoveUserGroupViewModel
    {
        public Guid? UserId { get; set; }

        public Guid? GroupId { get; set; }

        public string Redirect { get; set; }
    }
}
