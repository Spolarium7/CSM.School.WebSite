using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.AlumniProfiles
{
    public class CreateViewModel
    {
        [Required]
        public string Company { get; set; }

        [Required]
        public string Position { get; set; }


        [Required]
        public string Location { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime ToDate { get; set; }

        [Required]
        public DateTime FromDate { get; set; }
    }
}
