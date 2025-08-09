using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Net.Dto.Stocks;
using ASP.Net.Helpers;
using ASP.Net.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace ASP.Net.Repository
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject queryObject);
        Task<Stock?> GetByIdAsync(string id);
        Task<Stock?> GetSymbolAsync(string Symbol); 
        Task<Stock?> UpdateAsyns(string id, UpdateStockRequest updateStockRequest);
        Task<Stock?> CreateAsync(Stock stock);
        Task<Stock?> DeleteAsync(string id); 
    }
}