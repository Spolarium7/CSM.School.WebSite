using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers
{
    public class TextObjectPair<T>
    {
        public T Value { get; set; }

        public string Text { get; set; }
    }
}
