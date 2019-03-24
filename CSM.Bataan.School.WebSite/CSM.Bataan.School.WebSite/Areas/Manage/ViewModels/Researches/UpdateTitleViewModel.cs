using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Researches
{
    public class UpdateTitleViewModel
    {
        public Guid? Id { get; set; }

        public string Title { get; set; }

        public DateTime PostExpiry { get; set; }
    }
}
