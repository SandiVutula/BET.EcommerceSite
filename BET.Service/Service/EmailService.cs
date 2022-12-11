using BET.Data.Model.Dto;
using BET.Service.Contract;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Service.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public void SendEmailMessage(EmailDto email)
        {
            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
                emailMessage.To.Add(MailboxAddress.Parse(email.To));
                emailMessage.Subject = email.Subject;
                emailMessage.Body = new TextPart(TextFormat.Html)
                {
                    Text = email.Body
                };

                using var smtp = new SmtpClient();
                smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassoword").Value);
                smtp.Send(emailMessage);
                smtp.Disconnect(true);
                smtp.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
