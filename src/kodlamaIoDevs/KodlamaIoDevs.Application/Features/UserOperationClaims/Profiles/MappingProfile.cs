using AutoMapper;
using Core.Security.Entities;
using KodlamaIoDevs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
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
        }
    }
}
