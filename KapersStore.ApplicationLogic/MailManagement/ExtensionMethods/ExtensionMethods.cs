using KapersStore.ApplicationLogic.MailManagement.DTO;
using KapersStore.Domain.KaperManagement;
using KapersStore.Domain.MailManagement;
using KapersStore.Domain.UserManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.ApplicationLogic.MailManagement.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static MailDTO ToMailDto(this MailUser mu) =>
            new MailDTO
            {
                Id = mu.Mail.Id,
                Body = mu.Mail.Body,
                DateSent = mu.DateSent,
                IsSent = mu.IsSent,
                Subject = mu.Mail.Subject,
                Subscription = mu.Mail.Subscription.ToMailSubscriptionDto(),
                User = mu.User.ToMailUserDto()
            };

        public static MailSubscriptionDTO ToMailSubscriptionDto(this Subscription subscription) =>
            new MailSubscriptionDTO
            {
                Id = subscription.Id,
                KaperId = subscription.KaperId,
                Name = subscription.Name,
                KaperName = subscription.Kaper.Name
            };

        public static MailUserDTO ToMailUserDto(this User user) =>
            new MailUserDTO
            {
                Email = user.Email,
                Id = user.Id,
                Nickname = user.Nickname
            };
    }
}
