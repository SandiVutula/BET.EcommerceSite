using Azure;
using BET.Data.Model;
using BET.Data.Model.Dto;
using BET.Service.Contract;
using BET.Service.Service;
using BET.Shared.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace BET.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        #region Endpoints
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userExist = _userManager.FindByEmailAsync(user.EmailAddress);
                    if (userExist == null)
                    {
                        return BadRequest(new AuthResult()
                        {
                            Result = false,
                            Errors = new List<string>()
                        {
                            "Email already exist."
                        }
                        });
                    }

                    var createUser = new IdentityUser()
                    {
                        Email = user.EmailAddress,
                        UserName = user.EmailAddress
                    };

                    var isUserCreated = await _userManager.CreateAsync(createUser, user.Password);
                    if (isUserCreated.Succeeded)
                    {
                        //Generate token
                        var token = GenerateJwtToken(createUser);
                        return Ok(new AuthResult()
                        {
                            Result = true,
                            Token = token
                        });
                    }

                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>()
                        {
                            "An error occured while perfoming your request, contact admin"

                        },
                        Result = false
                    });
                }
            }
            catch (Exception x)
            {
                throw;
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto user)
        {

            if (ModelState.IsValid)
            {
                var userExist = await _userManager.FindByEmailAsync(user.EmailAddress);
                if (userExist == null)
                {
                    return BadRequest(new AuthResult()  
                    {
                        Errors = new List<string>()
                        {
                            "Account doesn't exist, please register to SignIn"
                        },
                        Result = false
                    });
                }

                var isCorrect = await _userManager.CheckPasswordAsync(userExist, user.Password);
                if (!isCorrect)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>()
                        {
                            "Incorrect username or password"
                        },
                        Result = false
                    });
                }

                var jwtToken = GenerateJwtToken(userExist);

                return Ok(new AuthResult()
                {
                    Token = jwtToken,
                    Result = true
                });

            }
            return BadRequest(new AuthResult()
            {
                Errors = new List<string>()
                {
                    "An error occured while perfoming your request, contact admin."
                },
                Result = false
            });
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            //await _signInManager.SignOutAsync();
            return Ok("You have been successfully logged out");

        }
        #endregion

        #region Private methods
        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);

            //Token Descriptor to fill all token info
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);


        }
        #endregion
    }
}
