using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.ViewModels.News;
using CSM.Bataan.School.WebSite.Infrastructure.Data.BusinessObjects;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Enums;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using CSM.Bataan.School.WebSite.Infrastructure.Security;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Controllers
{
    public class NewsController : Controller
    {
        private readonly DefaultDbContext _context;

        public NewsController(DefaultDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("/news")]
        [HttpGet, Route("/news/index")]
        public IActionResult Index()
        {
            List<Guid?> groups = new List<Guid?>();
            var publicGroup = this._context.Groups.FirstOrDefault(g => g.Name.ToLower() == "public");
            if (WebUser.IsAuthenticated)
            {
                groups = WebUser.Groups.Select(g => g.Id).ToList();
            }
            else
            {
                groups = new List<Guid?>();
                groups.Add(publicGroup.Id);
            }

            var newsList100 = this._context.News
            .Where(n => n.IsPublished == true && n.PostExpiry >= DateTime.UtcNow)
            .OrderByDescending(n => n.Timestamp)
            .Take(100)
            .Select(n => new NewsFeedItem()
            {
                Id = n.Id,
                Description = n.Description,
                Timestamp = n.Timestamp,
                Title = n.Title,
                UserId = n.UserId,
                IsPublished = n.IsPublished,
                PostExpiry = n.PostExpiry
            }).ToList();

            var news = new List<NewsFeedItem>();

            foreach (NewsFeedItem newsItem in newsList100)
            {
                var newsGroup = this._context.NewsGroups.FirstOrDefault(ng => ng.NewsItemId == newsItem.Id && groups.Contains(ng.GroupId));

                if (newsGroup != null)
                {
                    var user = this._context.Users.FirstOrDefault(u => u.Id == newsItem.UserId);

                    if (user != null)
                    {
                        newsItem.UserName = user.FullName;
                    }

                    newsItem.Type = ContentType.News;
                    news.Add(newsItem);
                }
            }

            return View(new IndexViewModel()
            {
                News = news.OrderByDescending(n => n.Timestamp).Take(10).ToList()
            });
        }

        [HttpGet, Route("/news/feed/{page}")]
        public List<NewsFeedItem> Feed(int page)
        {
            List<Guid?> groups = new List<Guid?>();
            var publicGroup = this._context.Groups.FirstOrDefault(g => g.Name.ToLower() == "public");
            if (WebUser.IsAuthenticated)
            {
                groups = WebUser.Groups.Select(g => g.Id).ToList();
            }
            else
            {
                groups = new List<Guid?>();
                groups.Add(publicGroup.Id);
            }

            var newsList1000 = this._context.News
            .Where(n => n.IsPublished == true && n.PostExpiry >= DateTime.UtcNow)
            .OrderByDescending(n => n.Timestamp)
            .Take(1000)
            .Select(n => new NewsFeedItem()
            {
                Id = n.Id,
                Description = n.Description,
                Timestamp = n.Timestamp,
                Title = n.Title,
                UserId = n.UserId,
                IsPublished = n.IsPublished,
                PostExpiry = n.PostExpiry
            }).ToList();

            var news = new List<NewsFeedItem>();

            foreach (NewsFeedItem newsItem in newsList1000)
            {
                var newsGroup = this._context.NewsGroups.FirstOrDefault(ng => ng.NewsItemId == newsItem.Id && groups.Contains(ng.GroupId.Value));

                if (newsGroup != null)
                {
                    var user = this._context.Users.FirstOrDefault(u => u.Id == newsItem.UserId);

                    if (user != null)
                    {
                        newsItem.UserName = user.FullName;
                    }

                    newsItem.Type = ContentType.News;
                    news.Add(newsItem);
                }
            }

            return news.OrderByDescending(n => n.Timestamp).Skip(page * 10).Take(10).ToList();
        }

        [HttpGet, Route("/news/{newsId}")]
        public IActionResult News(Guid? newsId)
        {
            var newsViewItem = new NewsViewItem();
            var newsItem = this._context.News.FirstOrDefault(n => n.Id == newsId);

            if(newsItem != null)
            {
                newsViewItem.Id = newsItem.Id;
                newsViewItem.Content = newsItem.Content;
                newsViewItem.Title = newsItem.Title;
                newsViewItem.Timestamp = newsItem.Timestamp;

                var user = this._context.Users.FirstOrDefault(u => u.Id == newsItem.UserId);

                if (user != null)
                {
                    newsViewItem.UserName = user.FullName;
                }

                List<string> groups = new List<string>();
                var newsGroups = this._context.NewsGroups.Where(ng => ng.NewsItemId == newsItem.Id);

                foreach (var newsGroup in newsGroups)
                {
                    var group = this._context.Groups.FirstOrDefault(g => g.Id == newsGroup.GroupId);

                    if (group != null)
                    {
                        groups.Add(group.Name);
                    }
                }

                newsViewItem.Groups = groups;
            }

            return View(newsViewItem);
        }
    }
}