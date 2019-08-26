using AutoMapper;
using KapersStore.ApplicationLogic.UserManagement.DTO;
using KapersStore.Domain.UserManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.ApplicationLogic.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}
