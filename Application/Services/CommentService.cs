using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public Comment GetComment(int Id)
        {
            return commentRepository.GetComment(Id);
        }

        public Comment SaveComment(Comment comment)
        {
            if (comment.Id > 0)
            {
                comment.UpdateDate = DateTime.Now;
                commentRepository.UpdateComment(comment);
            }
            else
            {
                commentRepository.AddComment(comment);
            }
            return comment;
        }

        public List<Comment> GetComments(int newsId)
        {
            return this.commentRepository.GetComments(newsId);
        }

        public List<Comment> GetCommentsByPropertyID(int propertyId)
        {
            return this.commentRepository.GetCommentsByPropertyID(propertyId);
        }

        public int GetCommentCount(int newsId)
        {
            return commentRepository.GetCommentCount(newsId);
        }
    }
}
