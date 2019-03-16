using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Threads;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ThreadsController : Controller
    {
        private readonly DefaultDbContext _context;
        private IHostingEnvironment _env;


        public ThreadsController(DefaultDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet, Route("manage/threads/index")]
        [HttpGet, Route("manage/threads")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 10, string keyword = "")
        {

            Page<Thread> result = new Page<Thread>();
            if (pageSize < 1)
            {
                pageSize = 1;
            }
            IQueryable<Thread> threadQuery = (IQueryable<Thread>)this._context.Threads;
            if (string.IsNullOrEmpty(keyword) == false)
            {
                threadQuery = threadQuery.Where(u => u.Title.ToLower().Contains(keyword.ToLower()));
            }
            long queryCount = threadQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<Thread> users = threadQuery.ToList();

            result.Items = users.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;


            return View(new IndexViewModel()
            {
                Threads = result
            });
        }

        [HttpGet, Route("manage/threads/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("manage/threads/create")]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            Thread thread = new Thread()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                Content = model.Content,
                UpdatedAt = model.UpdatedAt,
                IsPublished = true,
                TemplateName = "thread1"




            };
            this._context.Threads.Add(thread);
            this._context.SaveChanges();
            return View();
        }

        [HttpPost, Route("manage/threads/unpublish")]
        public IActionResult Unpublish(ThreadIdViewModel model)
        {
            var thread = this._context.Threads.FirstOrDefault(t => t.Id == model.Id);
            if (thread != null)
            {
                thread.IsPublished = false;
                this._context.Threads.Update(thread);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }

        [HttpPost, Route("manage/threads/publish")]
        public IActionResult Publish(ThreadIdViewModel model)
        {
            var thread = this._context.Threads.FirstOrDefault(t => t.Id == model.Id);

            if (thread != null)
            {
                thread.IsPublished = true;
                this._context.Threads.Update(thread);
                this._context.SaveChanges();
                return Ok();
            }
            return null;
        }
    }
}