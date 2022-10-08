using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using KodlamaIoDevs.Application.Features.Languages.Dtos;
using KodlamaIoDevs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using KodlamaIoDevs.Application.Features.UserOperationClaims.Dtos;
using KodlamaIoDevs.Application.Features.UserOperationClaims.Models;
using KodlamaIoDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.UserOperationClaims.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
            CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListModel>().ReverseMap();
            CreateMap<UserOperationClaim, GetUserOperationClaimByIdDto>().ForMember(x => x.UserName, opt => opt.MapFrom(u => u.User.FirstName)).ForMember(y => y.ClaimName, opt => opt.MapFrom(u => u.OperationClaim.Name)).ReverseMap();
        }
    }
}
