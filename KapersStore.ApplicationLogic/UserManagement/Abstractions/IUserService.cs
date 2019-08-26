using KapersStore.ApplicationLogic.UserManagement.DTO;
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
    }
}
