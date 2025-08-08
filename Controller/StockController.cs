using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.Net.Data;
using ASP.Net.Dto.Stocks;
using ASP.Net.Helpers;
using ASP.Net.Mapper;
using ASP.Net.Models;
using ASP.Net.Repository;
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
        private readonly IStockRepository _stockRepo;
        public StockController(ApplicationDBContext applicationDBContext, IStockRepository stockRepo)
        {
            _context = applicationDBContext;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject queryObject)
        {
            var stocks = await _stockRepo.GetAllAsync(queryObject);

            var stockDto = stocks.Select(s => s.ToStockDto());
            return Ok(stockDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var stock = await _stockRepo.GetByIdAsync(id);
            if (stock == null)
            {
                return NotFound();

            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequest stockRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            Stock stockModel = stockRequest.ToStockEntity();
            var StockCreated = await _stockRepo.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new { id = StockCreated.Id }, StockCreated.ToStockDto());

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateStockRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var stock = await _stockRepo.UpdateAsyns(id, request);
            if (stock == null)
                return NotFound();
            return Ok(stock.ToStockDto());



        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var stock = await _stockRepo.DeleteAsync(id);
            if (stock == null)
                return NotFound();
            return Ok(new { message = "Delete successful" });
        }

    }
}
