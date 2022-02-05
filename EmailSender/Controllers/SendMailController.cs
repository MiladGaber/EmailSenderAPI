using EmailSender.Core.Interfaces;
using EmailSender.Core.Models;
using EmailSender.Core.Services.EmailService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace EmailSender.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork<Email> _email;

        public SendMailController(
            IEmailSender emailSender,
            IConfiguration configuration,
            IUnitOfWork<Email> email)
        {
            _emailSender = emailSender;
            _configuration = configuration;
            _email = email;
        }


        [HttpPost("SendMailTo")]
        public async Task<IActionResult> SendMailTo(int id, UsersEmails usersEmails)
        {
            var emailData = await _email.Entity.GetByIdAsync(id);
            if (emailData == null) return BadRequest("Email Data Not Founded ! ");

            await _emailSender.SendEmailToManyAsync("milad@milad-gaber.me", usersEmails.Emails, emailData.Subject, emailData.Message);
            return Ok("Message Sent Succsusfully!");
        }
    }
}
