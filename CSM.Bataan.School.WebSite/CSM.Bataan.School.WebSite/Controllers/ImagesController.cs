using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Controllers
{
    public class ImagesController : Controller
    {
        private IHostingEnvironment _env;

        public ImagesController(IHostingEnvironment env)
        {
            _env = env;
        }

        [HttpGet, Route("/images/{contentType}/{contentid}/{guid}/{type}.png")]
        public IActionResult Image(string contentType, string type, string guid, string contentId)
        {
            var fullFilePath = this.GetFullFilePath(contentType, type, contentId);

            var image = System.IO.File.OpenRead(fullFilePath);

            return File(image, "image/jpeg");
        }

        private string GetFullFilePath(string contentType, string type, string contentId)
        {
            var dirPath = _env.WebRootPath + "/" + contentType.ToLower() + "/" + contentId + "/" + type + ".png";
            if (!System.IO.File.Exists(dirPath))
            {
                return _env.WebRootPath + "/images/" + contentType + "/" + type + "_default.png";
            }

            return dirPath;
        }
    }
}