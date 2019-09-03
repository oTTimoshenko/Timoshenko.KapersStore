using System;
using System.Collections.Generic;
using System.Text;
using KapersStore.Infrastructure.Helpers.MailSender.Models;

namespace KapersStore.Infrastructure.Helpers.MailSender
{
    public interface IMailSender
    {
        SendResult Send(SendMailModel model);
    }
}
