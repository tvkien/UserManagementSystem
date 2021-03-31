using Ums.Application.DTOs.Email;
using Ums.Application.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;
using Ums.Domain.Settings;

namespace Ums.Infrastructure.Shared.Services
{
    public class EmailService : IEmailService
    {
        public readonly MailSettings mailSettings;

        public EmailService(MailSettings mailSettings)
        {
            this.mailSettings = mailSettings;
        }

        public async Task SendAsync(EmailRequest request)
        {
            var email = BuildMimeMessage(request);

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(mailSettings.SmtpHost, mailSettings.SmtpPort, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(mailSettings.SmtpUser, mailSettings.SmtpPass);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

        private MimeMessage BuildMimeMessage(EmailRequest request)
        {
            var builder = new BodyBuilder
            {
                HtmlBody = request.Body
            };

            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(request.From ?? mailSettings.EmailFrom),
                Subject = request.Subject,
                Body = builder.ToMessageBody()
            };
            email.To.Add(MailboxAddress.Parse(request.To));

            return email;
        }
    }
}