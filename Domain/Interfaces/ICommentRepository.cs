using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICommentRepository
    {
        Comment AddComment(Comment comment);
        Comment GetComment(int Id);
        Comment UpdateComment(Comment comment);
        List<Comment> GetComments(int newsId);
        List<Comment> GetCommentsByPropertyID(int propertyId);
        int GetCommentCount(int newsId);
    }
}
