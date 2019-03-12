using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Groups
{
    public class UpdateViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
