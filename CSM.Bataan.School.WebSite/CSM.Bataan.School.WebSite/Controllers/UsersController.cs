using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Controllers
{
    public class UsersController : Controller
    {
        private readonly DefaultDbContext _context;

        public UsersController(DefaultDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("users")]
        [HttpGet, Route("users/look-up")]
        public List<TextValuePair> Lookup(string keyword, int count)
        {
            var users = this._context.Users.Where(u => u.FirstName.ToLower().StartsWith(keyword.ToLower()) || u.LastName.ToLower().StartsWith(keyword.ToLower())).Select(u => new TextValuePair() { Value = u.Id, Text = u.FullName })
                .OrderBy(a => a.Text)
                .Take(count)
                .Distinct()
                .ToList();

            return users;
        }

        [HttpGet, Route("groups")]
        [HttpGet, Route("users/add-user-to-group-look-up")]
        public List<TextValuePair> AddUserToGroupLookup(string keyword, int count = 5, Guid? groupId = null)
        {
            var userIds = this._context.UserGroups.Where(ug => ug.GroupId == groupId).Select(ug => ug.UserId).ToList();

            IQueryable<User> userQuery = (IQueryable<User>)this._context.Users.Where(u => !userIds.Contains(u.Id.Value));

            if (string.IsNullOrEmpty(keyword) == false)
            {
                userQuery = userQuery.Where(u => u.FirstName.ToLower().StartsWith(keyword.ToLower()) || u.LastName.ToLower().StartsWith(keyword.ToLower()) || u.EmailAddress.ToLower().StartsWith(keyword.ToLower()));
            }

            var users = userQuery.Select(u => new TextValuePair() { Value = u.Id, Text = u.FullName })
                   .OrderBy(a => a.Text)
                   .Take(count)
                   .Distinct()
                   .ToList();

            return users;
        }
    }
}