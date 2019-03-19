using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Controllers
{
    public class GroupsController : Controller
    {
        private readonly DefaultDbContext _context;

        public GroupsController(DefaultDbContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "SignedIn")]
        [HttpGet, Route("groups")]
        [HttpGet, Route("groups/look-up")]
        public List<TextValuePair> Lookup(string keyword, int count = 5)
        {
            IQueryable<Group> groupQuery = (IQueryable<Group>)this._context.Groups.Where(g => g.Status == Infrastructure.Data.Enums.Status.Active);

            if (string.IsNullOrEmpty(keyword) == false)
            {
                groupQuery = groupQuery.Where(g => g.Name.ToLower().StartsWith(keyword.ToLower()));
            }

             var groups = groupQuery.Select(g => new TextValuePair() { Value = g.Id, Text = g.Name })
                    .OrderBy(a => a.Text)
                    .Take(count)
                    .Distinct()
                    .ToList();

            return groups;
        }

        [Authorize(Policy = "SignedIn")]
        [HttpGet, Route("groups")]
        [HttpGet, Route("groups/add-user-to-group-look-up")]
        public List<TextValuePair> AddUserToGroupLookup(string keyword, int count = 5, Guid? userId = null)
        {
            var groupIds = this._context.UserGroups.Where(ug => ug.UserId == userId).Select(ug => ug.GroupId).ToList();

            IQueryable<Group> groupQuery = (IQueryable<Group>)this._context.Groups.Where(g => !groupIds.Contains(g.Id.Value) && g.Status == Infrastructure.Data.Enums.Status.Active);

            if (string.IsNullOrEmpty(keyword) == false)
            {
                groupQuery = groupQuery.Where(g => g.Name.ToLower().StartsWith(keyword.ToLower()));
            }

            var groups = groupQuery.Select(g => new TextValuePair() { Value = g.Id, Text = g.Name })
                   .OrderBy(a => a.Text)
                   .Take(count)
                   .Distinct()
                   .ToList();

            return groups;
        }


        [HttpGet, Route("groups")]
        [HttpGet, Route("groups/add-group-to-news-look-up")]
        public List<TextValuePair> AddGroupToNewsLookup(string keyword, int count = 5, Guid? newsId = null)
        {
            var groupIds = this._context.NewsGroups.Where(ng => ng.NewsItemId == newsId).Select(ng => ng.GroupId).ToList();

            IQueryable<Group> groupQuery = (IQueryable<Group>)this._context.Groups.Where(g => !groupIds.Contains(g.Id.Value) && g.Status == Infrastructure.Data.Enums.Status.Active);

            if (string.IsNullOrEmpty(keyword) == false)
            {
                groupQuery = groupQuery.Where(g => g.Name.ToLower().StartsWith(keyword.ToLower()));
            }

            var groups = groupQuery.Select(g => new TextValuePair() { Value = g.Id, Text = g.Name })
                   .OrderBy(a => a.Text)
                   .Take(count)
                   .Distinct()
                   .ToList();

            return groups;
        }
    }
}