using CSM.Bataan.School.WebSite.Infrastructure.Data.Enums;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Users
{
    public class IndexViewModel
    {
        public Page<User> Users { get; set; }

        public LoginStatus Status { get; set; }

        public List<LoginStatus> Statuses
        {
            get
            {
                return Enum.GetValues(typeof(LoginStatus)).Cast<LoginStatus>().ToList();
            }
        }
    }
}
