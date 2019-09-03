using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using KapersStore.Infrastructure.Helpers.MailSender.Models;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using Org.BouncyCastle.Crypto.Tls;

namespace KapersStore.Infrastructure.Helpers.MailSender
{
    public class MailKitSender : IMailSender
    {
        private readonly MailUser userFrom;
        private readonly MailClientConfiguration clientConfig;

        public MailKitSender()
        {
            userFrom = (MailUser) ConfigurationManager.GetSection("MailUser");
            clientConfig = (MailClientConfiguration) ConfigurationManager.GetSection("MailClient");
        }

        public SendResult Send(SendMailModel model)
        {
            try
            {
                var mailMessage = new MimeMessage();

                mailMessage.From.Add(new MailboxAddress(userFrom.Name, userFrom.Email));
                mailMessage.To.AddRange(model.EmailsToSend.Select(email => new MailboxAddress("", email)));

                mailMessage.Subject = model.Mail.Subject;
                mailMessage.Body = new TextPart(model.Mail.IsHtml ? TextFormat.Html : TextFormat.Text)
                {
                    Text = model.Mail.Body
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(clientConfig.Host, clientConfig.Port, false);
                    client.Authenticate(userFrom.Email, userFrom.Password);

                    client.Send(mailMessage);

                    client.Disconnect(true);
                }

                return SendResult.Success;
            }
            catch (Exception ex)
            {
                return SendResult.Error;
            }
        }
    }
}
