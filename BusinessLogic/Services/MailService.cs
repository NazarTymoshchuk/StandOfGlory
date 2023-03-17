using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit.Text;
using MimeKit;
using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Helpers;
using MailKit.Net.Smtp;
using BusinessLogic.Intefaces;

namespace BusinessLogic.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration configuration;

        public MailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendMailAsync(string subject, string html, string to, string? from = null)
        {
            MailData data = configuration.GetSection(nameof(MailData)).Get<MailData>();

            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from ?? data.Email));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(data.Host, data.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(data.Email, data.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
