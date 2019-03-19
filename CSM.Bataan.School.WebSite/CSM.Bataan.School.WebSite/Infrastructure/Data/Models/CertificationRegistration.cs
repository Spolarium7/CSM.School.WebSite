using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.Infrastructure.Data.Models
{
    public class CertificationRegistration : BaseModel
    {
        public Guid? UserId { get; set; }

        public Guid? CertificationId { get; set; }
    }
}
