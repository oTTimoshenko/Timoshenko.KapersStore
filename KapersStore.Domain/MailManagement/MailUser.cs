using KapersStore.Domain.UserManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.Domain.MailManagement
{
    public class MailUser
    {
        public int MailId { get; set; }
        public Mail Mail { get; set; }

        public int UserId { get; set; }
        public User User{ get; set; }

        public bool IsSent { get; set; }
        public DateTime? DateSent { get; set; }
    }
}
