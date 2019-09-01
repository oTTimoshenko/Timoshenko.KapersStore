using Api.CartManagement.Models;
using Api.KaperManagement.Models;
using Api.UserManagement.Models;
using AutoMapper;
using KapersStore.ApplicationLogic.CartManagement.DTO;
using KapersStore.ApplicationLogic.KaperManagement.DTO;
using KapersStore.ApplicationLogic.UserManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Configurations
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDTO, UserModel>().ReverseMap().MaxDepth(3);
            CreateMap<UserRegistrateDTO, UserRegistrateModel>().ReverseMap().MaxDepth(3);

            CreateMap<KaperDTO, KaperModel>().ReverseMap().MaxDepth(1);
            CreateMap<SubscriptionDTO, SubscriptionModel>().ReverseMap().MaxDepth(1);
            CreateMap<CommentModel, CommentDTO>()
                .ReverseMap()
                .MaxDepth(1)
                .ForMember(dest => dest.UserNickname, opt => opt.MapFrom(src => src.User.Nickname));

            CreateMap<CommentCreateDTO, CommentCreateModel>().ReverseMap().MaxDepth(1);
            CreateMap<CartDTO, CartModel>().ReverseMap();
            CreateMap<CartKaperDTO, CartKaperModel>().ReverseMap();
            CreateMap<CartSubscriptionDTO, CartSubscriptionModel>().ReverseMap();
        }
    }
}
