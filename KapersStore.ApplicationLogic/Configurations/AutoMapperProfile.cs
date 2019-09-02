using AutoMapper;
using KapersStore.ApplicationLogic.CartManagement.DTO;
using KapersStore.ApplicationLogic.KaperManagement.DTO;
using KapersStore.ApplicationLogic.UserManagement.DTO;
using KapersStore.Domain.CartManagement;
using KapersStore.Domain.KaperManagement;
using KapersStore.Domain.UserManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.ApplicationLogic.Configurations
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap().MaxDepth(3);
            CreateMap<KaperDTO, Kaper>().ReverseMap().MaxDepth(3);
            CreateMap<SubscriptionDTO, Subscription>().ReverseMap().MaxDepth(3);
            CreateMap<CommentDTO, Comment>().ReverseMap().MaxDepth(3);
            CreateMap<CartDTO, Cart>().ReverseMap()
        }
    }
}
