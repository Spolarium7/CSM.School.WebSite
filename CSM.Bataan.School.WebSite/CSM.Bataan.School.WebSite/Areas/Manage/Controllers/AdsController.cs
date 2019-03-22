using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Ads;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AdsController : Controller
    {
        private readonly DefaultDbContext _context;
        private IHostingEnvironment _env;


        public AdsController(DefaultDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet, Route("manage/ads/index")]
        [HttpGet, Route("manage/ads")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 2, string keyword = "")
        {

            Page<Ad> result = new Page<Ad>();
            if (pageSize < 1)
            {
                pageSize = 1;
            }
            IQueryable<Ad> adQuery = (IQueryable<Ad>)this._context.Ads;
            if (string.IsNullOrEmpty(keyword) == false)
            {
                adQuery = adQuery.Where(u => u.Title.ToLower().Contains(keyword.ToLower()));
            }
            long queryCount = adQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<Ad> users = adQuery.ToList();

            result.Items = users.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;


            return View(new IndexViewModel()
            {
                Ads = result
            });
        }

        [HttpGet, Route("manage/ads/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("manage/ads/create")]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            Ad ad = new Ad()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                Content = model.Content,
                PostExpiry = model.PostExpiry,
                IsPublished = true,
              




            };
            this._context.Ads.Add(ad);
            this._context.SaveChanges();
            return View();
        }

        [HttpPost, Route("manage/ads/unpublish")]
        public IActionResult Unpublish(AdIdViewModel model)
        {
            var ad = this._context.Ads.FirstOrDefault(p => p.Id == model.Id);
            if (ad != null)
            {
                ad.IsPublished = false;
                this._context.Ads.Update(ad);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }

        [HttpPost, Route("manage/ads/publish")]
        public IActionResult Publish(AdIdViewModel model)
        {
            var ad = this._context.Ads.FirstOrDefault(p => p.Id == model.Id);

            if (ad != null)
            {
                ad.IsPublished = true;
                this._context.Ads.Update(ad);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }
    }
}