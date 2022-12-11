using BET.Data.Model.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BET.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        [Route("email")]
        public IActionResult SendEmail(EmailDto email) 
        {
            if (email != null)
            {
                _emailService.SendEmailMessage(email);
                return Ok("Email sent successfully.");
            }
            else
            {
                return BadRequest("Something went wrong. Email not sent.");
            }
        }
    }
}
