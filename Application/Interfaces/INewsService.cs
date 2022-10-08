using System.Collections.Generic;
using Domain.Models;

namespace Application.Interfaces
{
    public interface INewsService
    {
        News SaveNews(News news);
        News GetNews(int Id);
        List<News> GetNewsList();
    }
}
