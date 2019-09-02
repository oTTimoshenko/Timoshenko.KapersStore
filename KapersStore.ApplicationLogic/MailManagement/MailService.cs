using AutoMapper;
using KapersStore.ApplicationLogic.MailManagement.Abstractions;
using KapersStore.ApplicationLogic.MailManagement.DTO;
using KapersStore.ApplicationLogic.MailManagement.ExtensionMethods;
using KapersStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KapersStore.ApplicationLogic.MailManagement
{
    public class MailService : IMailService
    {
        DataContext dataContext;
        IMapper mapper;

        public MailService(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
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

        public void SendEmailToUsers(MailSendDTO sendDto)
        {
            throw new NotImplementedException();
        }
    }
}
