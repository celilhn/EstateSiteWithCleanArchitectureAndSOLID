using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static Domain.Constants.Constants;

namespace CacheManagerApplication.Controllers
{
    public class NewsController : Controller
    {
        private readonly ITagService tagService;
        private readonly INewsService newsService;
        private readonly ICommentService commentService;
        private readonly IMemoryCache memoryCache;
        private readonly ICacheManager cacheManager;
        public NewsController(ITagService tagService, INewsService newsService, ICommentService commentService, IMemoryCache memoryCache, ICacheManager cacheManager)
        {
            this.tagService = tagService;
            this.newsService = newsService;
            this.commentService = commentService;
            this.memoryCache = memoryCache;
            this.cacheManager = cacheManager;
        }
        public IActionResult NewsList()
        {
            List<News> news = null;
            try
            {
                news = newsService.GetNewsList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return View(news);
        }

        public IActionResult Detail(int Id)
        {
            News news = null;
            News cacheNews = null;
            try
            {
                cacheNews = cacheManager.Get<News>(CacheArticleTypes.News + Id);
                if (cacheNews != null)
                {
                    news = cacheNews;
                    ViewBag.Comments = commentService.GetComments(news.Id);
                }
                else
                {
                    news = newsService.GetNews(Id);
                    ViewBag.Comments = news.Comments;
                    cacheManager.Set<News>(CacheArticleTypes.News + Id, news);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return View(news);
        }
    }
}