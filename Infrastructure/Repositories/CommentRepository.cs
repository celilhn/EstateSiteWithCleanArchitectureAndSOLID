using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using static Domain.Constants.Constants;

namespace Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CacheManagerDbContext context;
        public CommentRepository(CacheManagerDbContext context)
        {
            this.context = context;
        }

        public Comment AddComment(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
            return comment;
        }

        public Comment GetComment(int Id)
        {
            return context.Comments.SingleOrDefault(x => x.Id == Id);
        }

        public Comment UpdateComment(Comment comment)
        {
            context.Entry(comment).State = EntityState.Modified;
            context.SaveChanges();
            return comment;
        }

        public List<Comment> GetComments(int newsId)
        {
            return context.Comments.Where(x => x.NewsId == newsId).ToList();
        }

        public List<Comment> GetCommentsByPropertyID(int propertyId)
        {
            return context.Comments.Where(x => x.PropertyId == propertyId && x.Status == StatusCodes.Active).ToList();
        }

        public int GetCommentCount(int newsId)
        {
            return context.Comments.Where(x => x.NewsId == newsId && x.Status == StatusCodes.Active).Count();
        }
    }
}
