using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailSender.Core.Services.EmailService
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string from, string to, string subject, string message);
        Task SendEmailToManyAsync(string from, List<string> to, string subject, string message);
    }
}
