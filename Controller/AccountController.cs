


using ASP.Net.Dto;
using ASP.Net.Dto.Account;
using ASP.Net.Interface;
using ASP.Net.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net.Controller
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService; 
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDTO register)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var AppUser = new AppUser
                {
                    UserName = register.Username,
                    Email = register.Email
                };

                var createUser = await _userManager.CreateAsync(AppUser, register.Password);

                if (createUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(AppUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDTO
                            {
                                UserName = AppUser.UserName,
                                Email = AppUser.Email,
                                Token =_tokenService.CreateToken(AppUser)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createUser.Errors); 
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });

            }
        }

    }
}