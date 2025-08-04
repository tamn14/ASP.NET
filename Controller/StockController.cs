using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.Net.Data;
using ASP.Net.Dto.Stocks;
using ASP.Net.Mapper;
using ASP.Net.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace ASP.Net.Controller
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext applicationDBContext)
        {
            _context = applicationDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _context.Stocks.ToListAsync();

            var stockDto = stocks.Select(s => s.ToStockDto());
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();

            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequest stockRequest)
        {
            Stock stockModel = stockRequest.ToStockEntity();
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequest request)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }


            stock.Symbol = request.Symbol;
            stock.CompanyName = request.CompanyName;
            stock.Purchase = request.Purchase;
            stock.LastDiv = request.LastDiv;
            stock.Industry = request.Industry;
            stock.MarketCap = request.MarketCap;


            await _context.SaveChangesAsync();

            return Ok(stock.ToStockDto());

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Delete successful" });
        }

    }
}
