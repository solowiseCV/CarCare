using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CarCare.Infrastructure.Email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            try
            {
                var emailSettings = _configuration.GetSection("EmailSettings");
                if (emailSettings == null)
                {
                    _logger.LogError("EmailSettings section is missing from the configuration.");
                    throw new Exception("EmailSettings section is missing from the configuration.");
                }

                var senderName = emailSettings["SenderName"];
                var senderEmail = emailSettings["SenderEmail"];
                var smtpServer = emailSettings["SmtpServer"];
                var smtpPort = emailSettings["SmtpPort"];
                var username = emailSettings["Username"];
                var password = emailSettings["Password"];

                if (string.IsNullOrEmpty(senderName) || string.IsNullOrEmpty(senderEmail) || string.IsNullOrEmpty(smtpServer) || string.IsNullOrEmpty(smtpPort) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    _logger.LogError("One or more email settings are missing.");
                    throw new Exception("One or more email settings are missing.");
                }

                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress(senderName, senderEmail));
                emailMessage.To.Add(new MailboxAddress("", toEmail));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart("html") { Text = message };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(smtpServer, int.Parse(smtpPort), true);
                    await client.AuthenticateAsync(username, password);
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }
                _logger.LogInformation("Email sent successfully to {ToEmail} with subject {Subject}.", toEmail, subject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email to {ToEmail} with subject {Subject}.", toEmail, subject);
                throw;
            }
        }
    }
}