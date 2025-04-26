using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Services
{
    public class EmailService : IEmailService
    {
        private readonly ISmtpService _smtpService;

        private readonly ILogger<EmailService> _logger;

        public EmailService(ISmtpService smtpService, ILogger<EmailService> logger)
        {
            _smtpService = smtpService;
            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(string userEmail, string name, string subject, string body)
        {
            var _smtpSettings = _smtpService.GetSmtpSettings();
            var client = new SmtpClient();
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(name, _smtpSettings.Username));
                message.To.Add(new MailboxAddress("info", _smtpSettings.Username));
                message.Subject = subject;
                message.Body = new TextPart("plain") { Text = $"New message from {userEmail}\n" + body };
                
                var options = _smtpSettings.UseSsl ? SecureSocketOptions.StartTls : SecureSocketOptions.None;
                await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
                await client.SendAsync(message);


                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
            finally
            {
                await client.DisconnectAsync(true);
            }
        }
    }
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string from, string name, string subject, string body);
    }
}