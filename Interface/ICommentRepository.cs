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
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment?> CreateCommentAsync(Comment comment);
        Task<Comment?> UpdateCommentAsync(int id, UpdateComment updateComment);
        Task<Comment?> DeleteCommentAsync(int id); 
        
    }
}