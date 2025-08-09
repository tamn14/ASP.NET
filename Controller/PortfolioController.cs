using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Net.Extention;
using ASP.Net.Interface;
using ASP.Net.Models;
using ASP.Net.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net.Controller
{
    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepo;
        private readonly IPortfolioRepository _portpolioRepo;
        public PortfolioController(UserManager<AppUser> userManager,
                                    IStockRepository stockRepository,
                                    IPortfolioRepository portfolioRepository)
        {
            _userManager = userManager;
            _stockRepo = stockRepository;
            _portpolioRepo = portfolioRepository;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {
            var username = User.getUserName();
            var appUser = await _userManager.FindByEmailAsync(username);
            var userPortfolio = await _portpolioRepo.GetUserPortfolio(appUser);
            return Ok(userPortfolio);
        }



        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPortfolio(string Symbol)
        {
            var username = User.getUserName();
            var appUser = await _userManager.FindByNameAsync(username);
            var stock = await _stockRepo.GetSymbolAsync(Symbol);

            if (stock == null)
            {
                return BadRequest("Stock not found");
            }
            var userPortfolio = await _portpolioRepo.GetUserPortfolio(appUser);
            if (userPortfolio.Any(e => e.Symbol.ToLower() == Symbol.ToLower()))
            {
                return BadRequest("Can add same stock to portfolio");
            }

            var portfolioModel = new Portfolio
            {
                StockId = stock.Id,
                AppUserId = appUser.Id
            };


            await _portpolioRepo.CreateAsync(portfolioModel);
            if (portfolioModel == null)
            {
                return StatusCode(500, "Could not create");
            }
            else
            {
                return Created(); 
            }
            
        }


    }
}