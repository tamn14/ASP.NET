using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Net.Data;
using ASP.Net.Dto.Stocks;
using ASP.Net.Helpers;
using ASP.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;


        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock?> CreateAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock; 
        }

        public async Task<Stock?> DeleteAsync(string id)
        {
            // FirstOrDefaultAsync can get with many other props
            var Stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if (Stock == null)
            {
                return null;
            }
            _context.Stocks.Remove(Stock);
            await _context.SaveChangesAsync();
            return Stock; 
        }

        public async Task<List<Stock>> GetAllAsync(QueryObject queryObject)
        {
            var stocks = _context.Stocks.Include(c => c.Comments).AsQueryable();
            if (!string.IsNullOrWhiteSpace(queryObject.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName.Contains(queryObject.CompanyName));
            }

            if (!string.IsNullOrWhiteSpace(queryObject.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(queryObject.Symbol));
            }

            if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
            {
                if (queryObject.SortBy.Equals("Symbol" , StringComparison.OrdinalIgnoreCase))
                {
                    stocks = queryObject.IsDecsending
                                                    ? stocks.OrderByDescending(s => s.Symbol)
                                                    : stocks.OrderBy(s => s.Symbol);
                    
                }
            }

            var skipNummber = (queryObject.PageNumber - 1) * queryObject.PageSize; 
            return await stocks.Skip(skipNummber).Take(queryObject.PageSize).ToListAsync(); 
        }

        public async Task<Stock?> GetByIdAsync(string id)
        {
            return await _context.Stocks.Include(c=>c.Comments).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Stock?> UpdateAsyns(string id, UpdateStockRequest updateStockRequest)
        {
            // FirstOrDefaultAsync can get with many other props
            var existedStock = await _context.Stocks.Include(c=>c.Comments).FirstOrDefaultAsync(s => s.Id == id);
            if (existedStock == null)
            {
                return null;
            }
            existedStock.Symbol = updateStockRequest.Symbol;
            existedStock.CompanyName = updateStockRequest.CompanyName;
            existedStock.Purchase = updateStockRequest.Purchase;
            existedStock.LastDiv = updateStockRequest.LastDiv;
            existedStock.Industry = updateStockRequest.Industry;
            existedStock.MarketCap = updateStockRequest.MarketCap;

            await _context.SaveChangesAsync();
            return existedStock; 
        }
    }
}