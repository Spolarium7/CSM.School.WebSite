using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.UserGroups;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class UserGroupsController : Controller
    {
        private readonly DefaultDbContext _context;

        public UserGroupsController(DefaultDbContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("manage/user-groups/{userId}")]
        [HttpGet, Route("manage/user-groups/index/{userId}")]
        public IActionResult UserGroupIndex(Guid? userId, int pageSize = 5, int pageIndex = 1, string keyword = "")
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

            var groupIds = this._context.UserGroups.Where(g => g.UserId == userId).Select(g => g.GroupId).ToList();

            groupQuery = groupQuery.Where(g => groupIds.Contains(g.Id.Value));

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


            User user = this._context.Users.FirstOrDefault(u => u.Id == userId);

            return View(new GroupsIndexViewModel()
            {
                UserId = userId,
                UserName = (user != null ? user.FullName : ""),
                Groups = result
            });
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/group-users/add-user-to-group")]
        [HttpPost, Route("manage/user-groups/add-user-to-group")]
        public IActionResult Add(AddRemoveUserGroupViewModel model)
        {
            var duplicate = this._context.UserGroups.FirstOrDefault(ug => ug.UserId == model.UserId && ug.GroupId == model.GroupId);

            if(duplicate == null)
            {
                this._context.UserGroups.Add(new UserGroup() {
                    Id = Guid.NewGuid(),
                    UserId = model.UserId.Value,
                    GroupId = model.GroupId.Value
                });

                this._context.SaveChanges();
            }

            var redirect = "/manage/" + model.Redirect;

            return RedirectPermanent(redirect);
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpPost, Route("manage/group-users/remove-user-from-group")]
        [HttpPost, Route("manage/user-groups/remove-user-from-group")]
        public IActionResult Remove(AddRemoveUserGroupViewModel model)
        {
            var userGroup = this._context.UserGroups.FirstOrDefault(ug => ug.UserId == model.UserId && ug.GroupId == model.GroupId);

            if (userGroup != null)
            {
                this._context.UserGroups.Remove(userGroup);

                this._context.SaveChanges();
            }

            var redirect = "/manage/" + model.Redirect;

            return RedirectPermanent(redirect);
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("manage/group-users/{groupId}")]
        [HttpGet, Route("manage/group-users/index/{groupId}")]
        public IActionResult GroupUserIndex(Guid? groupId, int pageSize = 5, int pageIndex = 1, string keyword = "")
        {
            Page<User> result = new Page<User>();

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IQueryable<User> userQuery = (IQueryable<User>)this._context.Users;

            if (string.IsNullOrEmpty(keyword) == false)
            {
                userQuery = userQuery.Where(u => u.FirstName.Contains(keyword)
                                            || u.LastName.Contains(keyword)
                                            || u.EmailAddress.Contains(keyword));
            }

            var userIds = this._context.UserGroups.Where(u => u.GroupId == groupId).Select(g => g.UserId).ToList();

            userQuery = userQuery.Where(u => userIds.Contains(u.Id.Value));

            long queryCount = userQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<User> users = userQuery.ToList();

            result.Items = users.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;

            Group group = this._context.Groups.FirstOrDefault(g => g.Id == groupId);

            return View(new UsersIndexViewModel()
            {
                GroupId = groupId,
                GroupName = (group != null ? group.Name : ""),
                Users = result
            });
        }
    }
}