using KapersStore.Domain.KaperManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.Domain.MailManagement
{
    public class Mail
    {
        public int Id { get; set; }
        
        public string Subject { get; set; }
        public string Body { get; set; }

        public int SubscriptionId { get; set; }
        public Subscription Subscription{ get; set; }

        public List<MailUser> MailUsers { get; set; }

        public Mail()
        {
            MailUsers = new List<MailUser>();
        }
    }
}
