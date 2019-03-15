using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSM.Bataan.School.WebSite.ViewModels.Account
{
    public class UpdateProfileImageViewModel
    {
        public IFormFile ImageFile { get; set; }
    }
}
