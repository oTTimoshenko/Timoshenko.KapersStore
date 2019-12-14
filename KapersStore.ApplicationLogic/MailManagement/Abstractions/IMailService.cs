using KapersStore.ApplicationLogic.MailManagement.DTO;
using KapersStore.Infrastructure.Helpers.MailSender.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.ApplicationLogic.MailManagement.Abstractions
{
    public interface IMailService
    {
        void SendMailToUsers(MailSendDTO sendDto);
        IEnumerable<MailDTO> GetUserMails(int userId);
        IEnumerable<MailDTO> GetAllMails();
        IEnumerable<MailDTO> GetMailsByDate(DateTime date);
        IEnumerable<MailDTO> GetTodaysMails();
        SendResult SendResetPasswordMail(string email, string resetUrl);
        SendResult SendConfirmEmailMail(string email, string confirmUrl);
    }
}
