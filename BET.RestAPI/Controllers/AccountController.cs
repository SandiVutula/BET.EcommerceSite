using Azure;
using BET.Data.Model.Dto;
using BET.Service.Contract;
using BET.Service.Service;
using BET.Shared.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BET.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _iAccountService;

        #region Constructor 
        public AccountController(IAccountService iAccountService)
        {
            _iAccountService = iAccountService;
        }
        #endregion

        #region Endpoints

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            try
            {
                var userRegister = await _iAccountService.UserRegisterAsync(user);
                if (userRegister != null)
                {
                    return BadRequest("Username already exists");
                }

                if (user.Password != user.ConfirmPassword)
                {
                    return BadRequest("Passwords don't match");
                }

                user.Password = PasswordGenerator.HashPassword(user.Password);
                user.IsActive = true;

                return Ok(userRegister);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            try
            {
                var userLogin = await _iAccountService.UserLoginAsync(user);  
                return Ok(userLogin);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            //await _signInManager.SignOutAsync();
            return Ok("You have been successfully logged out");
           
        }

        #endregion
    }
}
