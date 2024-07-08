
using System.Net.Mail;

namespace LeaveManagementSystem.Web.Services
{
    public class EmailSender(IConfiguration _config) : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fromAddress = _config["EmailSettings:DefaultEmailAddress"];
            var smtpServer = _config["EmailSettings:Server"];
            var smtpPort = Convert.ToInt32(_config["EmailSettings:Port"]);
            var message = new MailMessage
            {
                From = new MailAddress(fromAddress),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            message.To.Add(new MailAddress(fromAddress));

            using var client = new SmtpClient(smtpServer, smtpPort);
            await client.SendMailAsync(message);
        }
    }
}
