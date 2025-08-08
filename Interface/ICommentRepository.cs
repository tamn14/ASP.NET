using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Net.Dto.Comment;
using ASP.Net.Models;

namespace ASP.Net.Interface
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(string id);
        Task<Comment?> CreateCommentAsync(Comment comment);
        Task<Comment?> UpdateCommentAsync(string id, UpdateComment updateComment);
        Task<Comment?> DeleteCommentAsync(string id); 
        
    }
}