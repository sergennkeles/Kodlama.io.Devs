using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using KodlamaIoDevs.Application.Features.Languages.Models;
using KodlamaIoDevs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using KodlamaIoDevs.Application.Features.OperationClaims.Dtos;
using KodlamaIoDevs.Application.Features.OperationClaims.Models;
using KodlamaIoDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.OperationClaims.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
            CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();


        }
    }
}
