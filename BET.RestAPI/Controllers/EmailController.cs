using BET.Data.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BET.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        [Route("email")]
        public IActionResult SendEmail(Email email) 
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
