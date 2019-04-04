using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.ViewModels.Home;
using CSM.Bataan.School.WebSite.Infrastructure.Data.BusinessObjects;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Enums;

namespace CSM.Bataan.School.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly DefaultDbContext _context;

        public HomeController(DefaultDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var publicGroup = this._context.Groups.FirstOrDefault(g => g.Name.ToLower() == "public");


            //Take top 10 news according to Time posted
            var newsList10 = this._context.News
       
                .Where(n => n.IsPublished == true && n.PostExpiry >= DateTime.UtcNow)
                .OrderByDescending(n => n.Timestamp)
                .Take(10)
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

            var publicNews = new List<NewsFeedItem>();

            foreach (NewsFeedItem newsItem in newsList10)
            {
                var newsGroup = this._context.NewsGroups.FirstOrDefault(ng => ng.NewsItemId == newsItem.Id && ng.GroupId == publicGroup.Id);

                if (newsGroup != null)
                {
                    var user = this._context.Users.FirstOrDefault(u => u.Id == newsItem.UserId);

                    if (user != null)
                    {
                        newsItem.UserName = user.FullName;
                    }

                    newsItem.Type = ContentType.News;
                    publicNews.Add(newsItem);
                }
            }

            return View(new IndexViewModel() {
                PublicNews = publicNews.OrderByDescending(n => n.Timestamp).Take(2).ToList()
                
            });

            
        }



        public IActionResult News()
        {
            return View();
        }

        [HttpGet, Route("schooldirectories")]
        public IActionResult SchoolDirectories()
        {
            return View();
        }
    }
}
