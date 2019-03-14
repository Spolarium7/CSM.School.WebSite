using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Groups;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class GroupsController : Controller
    {
        private readonly DefaultDbContext _context;

        public GroupsController(DefaultDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("manage/groups")]
        [HttpGet, Route("manage/groups/index")]
        public IActionResult Index(int pageSize = 5, int pageIndex = 1, string keyword = "")
        {
            Page<Group> result = new Page<Group>();

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IQueryable<Group> groupQuery = (IQueryable<Group>)this._context.Groups;

            if (string.IsNullOrEmpty(keyword) == false)
            {
                groupQuery = groupQuery.Where(g => g.Name.Contains(keyword)
                                            || g.Description.Contains(keyword));
            }

            long queryCount = groupQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<Group> groups = groupQuery.ToList();

            result.Items = groups.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;

            return View(new IndexViewModel()
            {
                Groups = result
            });
        }

        [HttpGet, Route("manage/groups/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("manage/groups/create")]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("index");

            var group = this._context.Groups.FirstOrDefault(u => u.Name.ToLower() == model.Name.ToLower());

            if (group == null)
            {
                group = new Group()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Description = model.Description
                };
                this._context.Groups.Add(group);

                this._context.SaveChanges();
            }

            return RedirectToAction("index");
        }

        [HttpGet, Route("manage/groups/update/{groupId}")]
        public IActionResult Update(Guid? groupId)
        {
            var group = this._context.Groups.FirstOrDefault(u => u.Id == groupId);

            if (group != null)
            {
                return View(
                    new UpdateViewModel()
                    {
                        Id = groupId,
                        Name = group.Name,
                        Description = group.Description,
                    }
                );
            }

            return RedirectToAction("create");
        }

        [HttpPost, Route("manage/groups/update")]
        public IActionResult UpdateProfile(UpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var group = this._context.Groups.FirstOrDefault(u => u.Id == model.Id);

            if (group != null)
            {
                group.Name = model.Name;
                group.Description = model.Description;
                this._context.Groups.Update(group);
                this._context.SaveChanges();
            }

            return RedirectToAction("index");
        }
    }
}