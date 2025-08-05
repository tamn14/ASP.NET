using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Net.Dto.Comment;
using ASP.Net.Models;

namespace ASP.Net.Mapper
{
    public static class CommentMapper
    {
        public static CommentDTO ToCommentDTO(this Comment comment)
        {
            return new CommentDTO
            {
                Id = comment.Id,
                Content = comment.Content,
                Title = comment.Title,
                CreatedOn = comment.CreatedOn,
                StockId = comment.StockId
            };
        }

        public static Comment ToCommentEntity(this CreateComment createComment)
        {
            return new Comment
            {
                Title = createComment.Title,
                Content = createComment.Content,
                CreatedOn = createComment.CreatedOn,
                StockId = createComment.StockId
            };
        }
    }
}