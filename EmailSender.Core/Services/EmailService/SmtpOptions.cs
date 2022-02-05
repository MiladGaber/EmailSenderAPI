namespace EmailSender.Core.Services.EmailService
{
    public class SmtpOptions
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
        public int Port { get; set; }
    }
}
