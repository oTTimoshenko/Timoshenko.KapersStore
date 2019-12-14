using KapersStore.Infrastructure.Helpers.MailSender.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System;
using System.Linq;

namespace KapersStore.Infrastructure.Helpers.MailSender
{
    public class MailKitSender : IMailSender
    {
        private readonly MailUser userFrom;
        private readonly MailClientConfiguration clientConfig;

        public MailKitSender(IOptions<MailUser> userOptions, IOptions<MailClientConfiguration> clientOptions)
        {
            userFrom = userOptions.Value;
            clientConfig = clientOptions.Value;
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
                    client.Connect(clientConfig.Host, clientConfig.Port, clientConfig.UseSsl);
                    
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
