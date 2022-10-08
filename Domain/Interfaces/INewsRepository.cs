using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface INewsRepository
    {
        News AddNews(News news);
        News UpdateNews(News news);
        News GetNews(int Id);
        List<News> GetNewsList();
    }
}
