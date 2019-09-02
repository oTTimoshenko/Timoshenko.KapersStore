using System;

namespace KapersStore.ApplicationLogic.MailManagement.DTO
{
    public class MailDTO
    {
        public int Id { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }

        public MailSubscriptionDTO Subscription { get; set; }
        public MailUserDTO User { get; set; }

        public bool IsSent { get; set; }
        public DateTime? DateSent { get; set; }
    }
}
