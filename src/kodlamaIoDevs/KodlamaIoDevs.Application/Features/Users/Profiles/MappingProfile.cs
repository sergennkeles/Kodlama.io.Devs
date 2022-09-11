using AutoMapper;
using Core.Security.JWT;
using KodlamaIoDevs.Application.Features.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Users.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AccessToken, TokenDto>().ReverseMap();
        }
    }
}
