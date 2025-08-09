using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Net.Data;
using ASP.Net.Interface;
using ASP.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDBContext _context;
        public PortfolioRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Stock>> GetUserPortfolio(AppUser user)
        {
            return await _context.Portfolios.Where(u => u.AppUserId == user.Id)
            .Select(Stock => new Stock
            {
                Id = Stock.StockId,
                CompanyName = Stock.stock.CompanyName,
                Purchase = Stock.stock.Purchase,
                Symbol = Stock.stock.Symbol,
                LastDiv = Stock.stock.LastDiv,
                Industry = Stock.stock.Industry,
                MarketCap = Stock.stock.MarketCap
            }).ToListAsync(); 
        }
    }
}