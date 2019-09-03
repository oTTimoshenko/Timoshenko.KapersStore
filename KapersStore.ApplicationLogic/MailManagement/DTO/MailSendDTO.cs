using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.ApplicationLogic.MailManagement.DTO
{
    public class MailSendDTO
    {
        public int SubscriptionId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> UsersEmails { get; set; }
    }
}
