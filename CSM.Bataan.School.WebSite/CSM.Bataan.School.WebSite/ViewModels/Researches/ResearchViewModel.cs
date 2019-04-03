using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.ViewModels.Researches
{
    public class ResearchViewModel
    {
        public Guid? ResearchId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Year { get; set; }



    }
}