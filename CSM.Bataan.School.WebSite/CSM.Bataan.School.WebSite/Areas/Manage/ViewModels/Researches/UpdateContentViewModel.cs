using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Researches
{
    public class UpdateContentViewModel
    {
        public Guid? ResearchId { get; set; }

         public string Title { get; set; }
        
        public string Content { get; set; }
    }
}
