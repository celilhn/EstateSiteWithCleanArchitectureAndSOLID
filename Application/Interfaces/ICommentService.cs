using System.Collections.Generic;
using Domain.Models;

namespace Application.Interfaces
{
    public interface ICommentService
    {
        Comment GetComment(int Id);
        Comment SaveComment(Comment comment);
        List<Comment> GetComments(int newsId);
        List<Comment> GetCommentsByPropertyID(int propertyId);
        int GetCommentCount(int newsId);
    }
}
