using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.UserRoles;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Enums;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class UserRolesController : Controller
    {
        private readonly DefaultDbContext _context;

        public UserRolesController(DefaultDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("manage/user-roles/{userId}")]
        [HttpGet, Route("manage/user-roles/index/{userId}")]
        public IActionResult Index(Guid? userId, int pageSize = 5, int pageIndex = 1, string keyword = "")
        {
            Page<Role> result = new Page<Role>();

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            var roles = this._context.UserRoles.Where(r => r.UserId == userId).Select(r => r.Role).ToList();

            if (string.IsNullOrEmpty(keyword) == false)
            {
                roles = roles.Where(r => r.ToString().Contains(keyword)).ToList();
            }

            long queryCount = roles.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));

            result.Items = roles.Skip(skip).Take((int)pageSize).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;


            User user = this._context.Users.FirstOrDefault(u => u.Id == userId);

            return View(new IndexViewModel()
            {
                UserId = userId,
                UserName = (user != null ? user.FullName : ""),
                Roles = result
            });
        }

        [HttpPost, Route("manage/user-roles/add-role-to-user")]
        public IActionResult Add(AddRemoveUserRoleViewModel model)
        {
            Enum.TryParse(model.Role, out Role role);
            var duplicate = this._context.UserRoles.FirstOrDefault(ur => ur.UserId == model.UserId && ur.Role == role);

            if (duplicate == null)
            {
                this._context.UserRoles.Add(new UserRole()
                {
                    Id = Guid.NewGuid(),
                    UserId = model.UserId.Value,
                    Role = role
                });

                this._context.SaveChanges();
            }

            var redirect = "/manage/user-roles/" + model.UserId;

            return RedirectPermanent(redirect);
        }

        [HttpPost, Route("manage/user-roles/remove-role-from-user")]
        public IActionResult Remove(AddRemoveUserRoleViewModel model)
        {
            Enum.TryParse(model.Role, out Role role);
            var userRole = this._context.UserRoles.FirstOrDefault(ur => ur.UserId == model.UserId && ur.Role == role);

            if (userRole != null)
            {
                this._context.UserRoles.Remove(userRole);

                this._context.SaveChanges();
            }

            var redirect = "/manage/user-roles/" + model.UserId;

            return RedirectPermanent(redirect);
        }
    }
}