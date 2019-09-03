using System.Collections.Generic;

namespace Api.MailManagement.Models
{
    public class MailSendModel
    {
        public int SubscriptionId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> UsersEmails { get; set; }
    }
}
