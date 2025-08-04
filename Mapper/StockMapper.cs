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

        public static Stock ToStockEntity(this CreateStockRequest request)
        {
            return new Stock
            {
                Symbol = request.Symbol,
                CompanyName = request.CompanyName,
                Purchase = request.Purchase,
                LastDiv = request.LastDiv,
                Industry = request.Industry,
                MarketCap = request.MarketCap

            }; 
        }
    }
}