using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Net.Data;
using ASP.Net.Dto.Comment;
using ASP.Net.Interface;
using ASP.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net.Repository
{

    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
       

        public async Task<Comment?> CreateCommentAsync(Comment comment)
        {
            var Stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == comment.StockId);
            if (Stock == null)
            {
                return null;
            }
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;

        }

        public async Task<Comment?> DeleteCommentAsync(int id)
        {
            var Comment = await _context.Comments.FirstOrDefaultAsync(s => s.Id == id);
            if (Comment == null)
            {
                return null;
            }
            _context.Comments.Remove(Comment);
            await _context.SaveChangesAsync();
            return Comment; 
            
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id); 

        }

        public async Task<Comment?> UpdateCommentAsync(int id, UpdateComment updateComment)
        {
            var Comment = await _context.Comments.FirstOrDefaultAsync(s => s.Id == id);
            var Stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == updateComment.StockId); 
            if (Comment == null)
            {
                return null;
            }
            if (Stock == null)
            {
                return null; 
            }
            Comment.Title = updateComment.Title;
            Comment.Content = updateComment.Content;
            Comment.StockId = updateComment.StockId;

            await _context.SaveChangesAsync();
            return Comment; 
            

        }
    }
}