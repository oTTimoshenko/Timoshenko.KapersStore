using System.Collections.Generic;

namespace KapersStore.Infrastructure.Helpers.MailSender.Models
{
    public class SendMailModel
    {
        public List<string> EmailsToSend { get; set; }
        public Mail Mail { get; set; }
    }

    public class Mail
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; } = true;
    }

    public class MailClientConfiguration
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; } = false;
    }

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public enum SendResult
    {
        Success,
        Error
    }
}
