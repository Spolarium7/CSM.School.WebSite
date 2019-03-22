﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.AlumniProfiles
{
    public class UpdateTitleViewModel
    {
        public Guid? AlumniProfileId { get; set; }

        public string Company { get; set; }

        public string Position { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }


    }
}