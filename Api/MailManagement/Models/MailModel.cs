using System;

namespace Api.MailManagement.Models
{
    public class MailModel
    {
        public int Id { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }

        public MailSubscriptionModel Subscription { get; set; }
        public MailUserModel User { get; set; }

        public bool IsSent { get; set; }
        public DateTime? DateSent { get; set; }
    }
}
