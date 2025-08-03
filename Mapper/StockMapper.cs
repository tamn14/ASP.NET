using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Net.Dto.Stocks;
using ASP.Net.Models;

namespace ASP.Net.Mapper
{
    public static class StockMapper
    {
        public static StocksDto ToStockDto(this Stock stock)
        {
            return new StocksDto
            {
                Id = stock.Id,
                Symbol = stock.Symbol,
                CompanyName = stock.CompanyName,
                Purchase = stock.Purchase,
                LastDiv = stock.LastDiv,
                Industry = stock.Industry,
                MarketCap = stock.MarketCap
            }; 
        }
    }
}