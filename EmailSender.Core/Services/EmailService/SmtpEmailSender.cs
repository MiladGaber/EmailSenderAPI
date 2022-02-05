using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailSender.Core.Services.EmailService
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly IOptions<SmtpOptions> _options;

        public SmtpEmailSender(IOptions<SmtpOptions> options)
        {
            _options = options;
        }
        public async Task SendEmailAsync(string from, string to, string subject, string message)
        {
            var mailMessage = new MailMessage(from, to, subject, message);

            using (var client = new SmtpClient(_options.Value.Host, _options.Value.Port)
            {
                Credentials = new NetworkCredential(_options.Value.Username, _options.Value.password)
            })
            {
                await client.SendMailAsync(mailMessage); //need to add to Startup config
            }
        }

        public async Task SendEmailToManyAsync(string from, List<string> to, string subject, string message)
        {
            foreach (var item in to)
            {
                if (item != "") await SendEmailAsync(from, item, subject, message);
            }
        }
    }
}
