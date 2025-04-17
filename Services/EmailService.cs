using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<SmtpSettings> smtpSettings, ILogger<EmailService> logger)
        {
            _smtpSettings = smtpSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(string userEmail, string name, string subject, string body)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(name, _smtpSettings.Username));
                message.To.Add(new MailboxAddress("info", _smtpSettings.Username));
                message.Subject = subject;
                message.Body = new TextPart("plain") { Text = $"New message from {userEmail}\n" + body };

                using (var client = new SmtpClient())
                {
                    var options = _smtpSettings.UseSsl ? SecureSocketOptions.StartTls : SecureSocketOptions.None;
                    await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }

        }

    }
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string from, string name, string subject, string body);
    }
}