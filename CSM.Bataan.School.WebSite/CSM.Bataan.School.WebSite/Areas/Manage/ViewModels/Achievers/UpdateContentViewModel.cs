using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Achievers
{
    public class UpdateContentViewModel
    {
        public Guid? AchieverId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}