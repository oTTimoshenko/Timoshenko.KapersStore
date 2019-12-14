using KapersStore.ApplicationLogic.UserManagement.DTO;
using KapersStore.Infrastructure.Helpers.MailSender.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.ApplicationLogic.UserManagement.Abstractions
{
    public interface IUserService
    {
        UserDTO Authenticate(string email, string password);
        void Registrate(UserRegistrateDTO user);
        UserDTO GetById(int id);
        void RequestResetPasswordMail(string email);
        void ConfirmEmail(string email, string code);
        void ResetPassword(string email, string userCode, string newPassword);
    }
}
