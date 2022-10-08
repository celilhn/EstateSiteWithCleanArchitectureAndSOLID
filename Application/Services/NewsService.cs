using System;
using System.Collections.Generic;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository newsRepository;
        private readonly IMapper mapper;
        public NewsService(INewsRepository newsRepository, IMapper mapper)
        {
            this.newsRepository = newsRepository;
            this.mapper = mapper;
        }

        public News SaveNews(News news)
        {
            if (news.Id > 0)
            {
                news.UpdateDate = DateTime.Now;
                newsRepository.UpdateNews(news);
            }
            else
            {
                newsRepository.AddNews(news);
            }
            return news;
        }

        public News GetNews(int Id)
        {
            return this.newsRepository.GetNews(Id);
        }

        public List<News> GetNewsList()
        {
            return this.newsRepository.GetNewsList();
        }
    }
}
