using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Enums;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Controllers
{
    public class RolesController : Controller
    {
        private readonly DefaultDbContext _context;

        public RolesController(DefaultDbContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "AuthorizeAdmin")]
        [HttpGet, Route("roles/add-role-to-user-look-up")]
        public List<TextObjectPair<Role>> AddRoleToUserLookup(string keyword, int count = 5, Guid? userId = null)
        {
            var userRoles = this._context.UserRoles.Where(r => r.UserId == userId).Select(r => r.Role).ToList();

            var roles = Enum.GetValues(typeof(Role)).Cast<Role>();

            roles = roles.Where(r => !userRoles.Contains(r));

            if (string.IsNullOrEmpty(keyword) == false)
            {
                roles = roles.Where(r => r.ToString().Contains(keyword)).ToList();
            }

            var roleResults = roles.Select(r => new TextObjectPair<Role>() { Value = r, Text = r.ToString() })
                   .OrderBy(a => a.Text)
                   .Take(count)
                   .Distinct()
                   .ToList();

            return roleResults;
        }
    }
}