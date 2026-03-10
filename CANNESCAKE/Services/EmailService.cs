using System.Net.Mail;
using System.Net;

namespace CANNESCAKE.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try 
            {
                var smtpSettings = _configuration.GetSection("SmtpSettings");
                var client = new SmtpClient(smtpSettings["Server"], int.Parse(smtpSettings["Port"]))
                {
                    Credentials = new NetworkCredential(smtpSettings["Username"], smtpSettings["Password"]),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpSettings["SenderEmail"], smtpSettings["SenderName"]),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(email);

                await client.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                // In production, log this error
                Console.WriteLine($"Email send failed: {ex.Message}");
            }
        }
    }
}
