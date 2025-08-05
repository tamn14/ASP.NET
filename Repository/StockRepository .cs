using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Net.Data;
using ASP.Net.Dto.Stocks;
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

        public async Task<Stock?> DeleteAsync(int id)
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

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public async Task<Stock?> UpdateAsyns(int id, UpdateStockRequest updateStockRequest)
        {
            // FirstOrDefaultAsync can get with many other props
            var existedStock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
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