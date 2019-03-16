﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.News;
using CSM.Bataan.School.WebSite.Infrastructure.Data.BusinessObjects;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Helpers;
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CSM.Bataan.School.WebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class NewsController : Controller
    {
        private readonly DefaultDbContext _context;
        private IHostingEnvironment _env;

        public NewsController(DefaultDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet, Route("manage/news/index")]
        [HttpGet, Route("manage/news")]
        public IActionResult Index(int pageIndex = 1, int pageSize = 2, string keyword = "")
        {
            Page<NewsFeedItem> result = new Page<NewsFeedItem>();

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IQueryable<NewsItem> newsQuery = (IQueryable<NewsItem>)this._context.News;

            if (string.IsNullOrEmpty(keyword) == false)
            {
                newsQuery = newsQuery.Where(u => u.Title.ToLower().Contains(keyword.ToLower()));
            }

            long queryCount = newsQuery.Count();

            int pageCount = (int)Math.Ceiling((decimal)(queryCount / pageSize));
            long mod = (queryCount % pageSize);

            if (mod > 0)
            {
                pageCount = pageCount + 1;
            }

            int skip = (int)(pageSize * (pageIndex - 1));
            List<NewsItem> news = newsQuery.ToList();

            result.Items = news.Skip(skip).Take((int)pageSize).Select(n => new NewsFeedItem() {
                Id = n.Id,
                Description = n.Description,
                Timestamp = n.Timestamp,
                Title = n.Title,
                UserId = n.UserId
            }).OrderByDescending(n => n.Timestamp).ToList();
            result.PageCount = pageCount;
            result.PageSize = pageSize;
            result.QueryCount = queryCount;
            result.PageIndex = pageIndex;
            result.Keyword = keyword;

            //Get User Names
            foreach(NewsFeedItem item in result.Items)
            {
                var user = this._context.Users.FirstOrDefault(u => u.Id == item.UserId);

                if (user != null)
                {
                    item.UserName = user.FullName;
                }
            }

            return View(new IndexViewModel()
            {
                News = result
            });
        }
    }
}