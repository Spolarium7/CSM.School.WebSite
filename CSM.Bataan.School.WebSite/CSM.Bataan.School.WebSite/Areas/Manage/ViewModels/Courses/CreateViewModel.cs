﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Courses
{
    public class CreateViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Year { get; set; }

        [Required]
        public string CourseCode { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime PostExpiry { get; set; }


    }
}