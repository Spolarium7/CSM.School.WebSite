using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Faqs
{
    public class CreateViewModel
    {
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime PostExpiry { get; set; }
    }
}