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


    }
}