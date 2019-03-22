using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.ViewModels.Courses
{
    public class CoursesViewModel
    {
        public Guid? CourseId { get; set; }

        public string Title { get; set; }

        public DateTime Year { get; set; }

        public string CourseCode { get; set; }

        public string Content { get; set; }

        public DateTime PostExpiry { get; set; }

    }
}
