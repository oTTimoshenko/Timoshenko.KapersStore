using Api.UserManagement.Models;
using AutoMapper;
using KapersStore.ApplicationLogic.UserManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDTO, UserModel>().ReverseMap();
            CreateMap<UserRegistrateDTO, UserRegistrateModel>().ReverseMap();
        }
    }
}
