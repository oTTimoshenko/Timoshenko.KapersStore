using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.ApplicationLogic.MailManagement.DTO
{
    public class MailSubscriptionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int KaperId { get; set; }
        public string KaperName { get; set; }

    }
}
