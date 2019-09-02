using KapersStore.ApplicationLogic.MailManagement.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.ApplicationLogic.MailManagement.Abstractions
{
    public interface IMailService
    {
        void SendEmailToUsers(MailSendDTO sendDto);
        IEnumerable<MailDTO> GetUserMails(int userId);
        IEnumerable<MailDTO> GetAllMails();
        IEnumerable<MailDTO> GetMailsByDate(DateTime date);
        IEnumerable<MailDTO> GetTodaysMails();
    }
}
