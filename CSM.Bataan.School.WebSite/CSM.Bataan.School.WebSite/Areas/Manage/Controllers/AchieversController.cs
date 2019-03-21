using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Achievers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AchieversController : Controller
    {
        private readonly DefaultDbContext _context;
        private IHostingEnvironment _env;
        public AchieversController(DefaultDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet, Route("manage/achievers/index")]
        [HttpGet, Route("manage/achievers")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 10, string keyword = "")
        {

            Page<Achiever> result = new Page<Achiever>();
            if (pageSize < 1)
            {
                pageSize = 1;
            }
            IQueryable<Achiever> achieverQuery = (IQueryable<Achiever>)this._context.Achievers;
            if (string.IsNullOrEmpty(keyword) == false)
            {
                achieverQuery = achieverQuery.Where(u => u.Title.ToLower().Contains(keyword.ToLower()));
            }
            long queryCount = achieverQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<Achiever> users = achieverQuery.ToList();

            result.Items = users.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;


            return View(new IndexViewModel()
            {
                Achievers = result
            });
        }


        [HttpGet, Route("manage/achievers/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("manage/achievers/create")]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
           Achiever achiever = new Achiever()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Content = model.Content,
                PostExpiry = model.PostExpiry,
                IsPublished = true,
                TemplateName = "achiever1"




            };
            this._context.Achievers.Add(achiever);
            this._context.SaveChanges();
            return View();
        }


        [HttpPost, Route("manage/achievers/unpublish")]
        public IActionResult Unpublish(AchieverIdViewModel model)
        {
            var achiever = this._context.Achievers.FirstOrDefault(t => t.Id == model.Id);
            if (achiever != null)
            {
                achiever.IsPublished = false;
                this._context.Achievers.Update(achiever);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }

        [HttpPost, Route("manage/achievers/publish")]
        public IActionResult Publish(AchieverIdViewModel model)
        {
            var achiever = this._context.Achievers.FirstOrDefault(t => t.Id == model.Id);

            if (achiever != null)
            {
                achiever.IsPublished = true;
                this._context.Achievers.Update(achiever);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }


        [HttpGet, Route("/manage/achievers/update-title/{achieverId}")]
        public IActionResult UpdateTitle(Guid? achieverId)
        {
            var achiever = this._context.Achievers.FirstOrDefault(p => p.Id == achieverId);
            if (achiever != null)
            {
                var model = new UpdateTitleViewModel()
                {
                    Id = achiever.Id,
                    Title = achiever.Title,
                    PostExpiry = achiever.PostExpiry,
                  

                };
                return View(model);
            }
            return RedirectToAction("Create");
        }

        [HttpPost, Route("/manage/achievers/update-title")]
        public IActionResult UpdateTitle(UpdateTitleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var achiever = this._context.Achievers.FirstOrDefault(p => p.Id == model.Id);

            if (achiever != null)
            {
                achiever.PostExpiry = model.PostExpiry;
                achiever.Title = model.Title;
               

                this._context.Achievers.Update(achiever);
                this._context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}