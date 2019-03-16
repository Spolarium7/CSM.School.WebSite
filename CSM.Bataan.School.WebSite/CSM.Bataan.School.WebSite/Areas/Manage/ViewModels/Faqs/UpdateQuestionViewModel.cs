using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Faqs
{
    public class UpdateQuestionViewModel
    {
        public Guid? Id { get; set; }

        public string Question { get; set; }

        public string TemplateName { get; set; }

        public DateTime PostExpiry { get; set; }
    }
}