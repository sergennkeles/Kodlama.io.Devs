using AutoMapper;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.Socials.Commands.CreateSocial;
using KodlamaIoDevs.Application.Features.Socials.Dtos;
using KodlamaIoDevs.Application.Features.Socials.Models;
using KodlamaIoDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Socials.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Social, CreateSocialCommand>().ReverseMap();
            CreateMap<Social, CreateSocialDto>().ReverseMap();
            CreateMap<IPaginate<Social>, SocialAccountListModel>().ReverseMap();
            CreateMap<Social, SocialAccountListDto>().ForMember(x=>x.UserName,opt=>opt.MapFrom(x=>x.User.FirstName)).ReverseMap();


        }
    }
   
}
