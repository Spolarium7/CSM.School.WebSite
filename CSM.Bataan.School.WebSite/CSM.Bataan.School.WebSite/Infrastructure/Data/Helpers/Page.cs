using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers
{
    public class Page<T>
    {
        public List<T> Items { get; set; }

        public long QueryCount { get; set; }

        public long PageCount { get; set; }

        public long PageSize { get; set; }

        public long PageIndex { get; set; }

        public string Keyword { get; set; }
    }
}
