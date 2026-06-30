using System.Net;
using System.Net.Mail;
using MikayilHavaYollari.Models;

namespace MikayilHavaYollari.Helper
{
    public class ContactEmailService : IContactEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ContactEmailService> _logger;

        public ContactEmailService(IConfiguration configuration, ILogger<ContactEmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task SendContactNotificationAsync(GetInTouch contact, CancellationToken cancellationToken = default)
        {
            var settings = _configuration.GetSection("EmailSettings");
            var senderEmail = settings["SenderEmail"]
                ?? throw new InvalidOperationException("EmailSettings:SenderEmail is not configured.");
            var senderPassword = settings["SenderPassword"]
                ?? throw new InvalidOperationException("EmailSettings:SenderPassword is not configured.");
            var adminEmail = settings["AdminEmail"] ?? senderEmail;
            var senderName = settings["SenderName"] ?? "MikayilHavaYollariApp";
            var smtpHost = settings["SmtpHost"] ?? "smtp.gmail.com";
            var smtpPort = int.Parse(settings["SmtpPort"] ?? "587");

            using var message = new MailMessage
            {
                From = new MailAddress(senderEmail, senderName),
                Subject = $"Yeni Contact Mesaji: {contact.Subject}",
                Body = $"""
                    Contact formundan yeni mesaj gəldi.

                    Ad: {contact.UserName}
                    Email: {contact.Email}
                    Mövzu: {contact.Subject}

                    Mesaj:
                    {contact.Message}
                    """,
                IsBodyHtml = false
            };

            message.To.Add(adminEmail);
            message.ReplyToList.Add(new MailAddress(contact.Email, contact.UserName));

            using var client = new SmtpClient(smtpHost, smtpPort)
            {
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true
            };

            await client.SendMailAsync(message, cancellationToken);
            _logger.LogInformation("Contact notification email sent for message from {Email}", contact.Email);
        }
    }
}
