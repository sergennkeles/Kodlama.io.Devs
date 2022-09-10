using AutoMapper;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.Technologies.Commands.CreateTechnology;
using KodlamaIoDevs.Application.Features.Technologies.Dtos;
using KodlamaIoDevs.Application.Features.Technologies.Models;
using KodlamaIoDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Technologies.Profiles
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<Technology, CreateTechnologyDto>().ReverseMap();
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
            CreateMap<Technology,UpdateTechnologyDto>().ReverseMap();
            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
            CreateMap<Technology, TechnologyListDto>().ReverseMap();
            CreateMap<Technology, GetByIdTechnologyDto>().ReverseMap();
            

        }
    }
}
