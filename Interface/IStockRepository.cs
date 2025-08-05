using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Net.Dto.Stocks;
using ASP.Net.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace ASP.Net.Repository
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);

        Task<Stock?> UpdateAsyns(int id, UpdateStockRequest updateStockRequest);
        Task<Stock?> CreateAsync(Stock stock);
        Task<Stock?> DeleteAsync(int id); 
    }
}