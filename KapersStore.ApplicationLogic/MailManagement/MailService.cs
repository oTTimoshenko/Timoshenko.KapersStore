using AutoMapper;
using KapersStore.ApplicationLogic.MailManagement.Abstractions;
using KapersStore.ApplicationLogic.MailManagement.DTO;
using KapersStore.ApplicationLogic.MailManagement.ExtensionMethods;
using KapersStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using KapersStore.Domain.MailManagement;
using KapersStore.Infrastructure.ExtensionMethods;
using KapersStore.Infrastructure.Helpers.MailSender;
using KapersStore.Infrastructure.Helpers.MailSender.Models;
using Mail = KapersStore.Infrastructure.Helpers.MailSender.Models.Mail;

namespace KapersStore.ApplicationLogic.MailManagement
{
    public class MailService : IMailService
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly IMailSender mailSender;

        public MailService(DataContext dataContext, IMapper mapper, IMailSender mailSender)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.mailSender = mailSender;
        }

        public IEnumerable<MailDTO> GetAllMails() =>
            dataContext.MailUsers.Select(mailUser => mailUser.ToMailDto());

        public IEnumerable<MailDTO> GetMailsByDate(DateTime date) =>
            dataContext.MailUsers.Where(mu => mu.DateSent.HasValue && mu.DateSent.Value.Date == date.Date)
                                 .Select(mailUser => mailUser.ToMailDto());

        public IEnumerable<MailDTO> GetTodaysMails() =>
            GetMailsByDate(DateTime.UtcNow);

        public IEnumerable<MailDTO> GetUserMails(int userId) =>
            dataContext.MailUsers.Where(mailUser => mailUser.UserId == userId)
                                 .Select(mailUser => mailUser.ToMailDto());

        public void SendMailToUsers(MailSendDTO sendDto)
        {
            var result = mailSender.Send(new SendMailModel()
            {
                EmailsToSend = sendDto.UsersEmails,
                Mail = new Mail()
                {
                    Subject = sendDto.Subject,
                    Body = sendDto.Body,
                    IsHtml = true
                }
            });

            SaveSentMails(sendDto, result == SendResult.Success);
        }

        private void SaveSentMails(MailSendDTO sendDto, bool isSent)
        {
            var users = dataContext.Users.Where(user =>
                sendDto.UsersEmails.Any(ue => ue.Equals(user.Email, StringComparison.OrdinalIgnoreCase)));

            var subscription = dataContext.Subscriptions.Get(sendDto.SubscriptionId);

            var mail = new Domain.MailManagement.Mail
            {
                Subject = sendDto.Subject,
                Body = sendDto.Subject,
                Subscription = subscription
            };

            dataContext.Mails.Add(mail);

            var mailUsers = users.Select(user => new Domain.MailManagement.MailUser
            {
                User = user,
                IsSent = isSent,
                Mail = mail,
                DateSent = isSent ? DateTime.UtcNow : (DateTime?) null
            });

            dataContext.MailUsers.AddRange(mailUsers);
            dataContext.SaveChanges();
        }
    }
}
