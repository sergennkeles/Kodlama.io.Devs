using AutoMapper;
using KodlamaIoDevs.Application.Features.Socials.Commands.CreateSocial;
using KodlamaIoDevs.Application.Features.Socials.Dtos;
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
        }
    }
   
}
