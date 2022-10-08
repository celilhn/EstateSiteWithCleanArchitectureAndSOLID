using System.Collections.Generic;
using System.Linq;
using Domain.Constants;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using static Domain.Constants.Constants;

namespace Infrastructure.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly CacheManagerDbContext context;
        public NewsRepository(CacheManagerDbContext context)
        {
            this.context = context;
        }

        public News AddNews(News news)
        {
            context.News.Add(news);
            context.SaveChanges();
            return news;
        }

        public News UpdateNews(News news)
        {
            context.Entry(news).State = EntityState.Modified;
            context.SaveChanges();
            return news;
        }

        public News GetNews(int Id)
        {
            return context.News.SingleOrDefault(x => x.Id == Id);
        }

        public List<News> GetNewsList()
        {
            return context.News.Where(x => x.Status == StatusCodes.Active).ToList();
        }
    }
}
