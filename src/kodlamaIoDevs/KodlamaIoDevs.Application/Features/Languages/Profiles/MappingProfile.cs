using AutoMapper;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.Languages.Commands.CreateLanguage;
using KodlamaIoDevs.Application.Features.Languages.Commands.UpdateLanguage;
using KodlamaIoDevs.Application.Features.Languages.Dtos;
using KodlamaIoDevs.Application.Features.Languages.Models;
using KodlamaIoDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Languages.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Language, CreateLanguageDto>().ReverseMap();
            CreateMap<Language, CreateLanguageCommand>().ReverseMap();
            CreateMap<Language, UpdateLanguageDto>().ReverseMap();
            CreateMap<Language, UpdateLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<Language>, LanguageListModel>().ReverseMap();
            CreateMap<Language,LanguageListDto>().ReverseMap();
            CreateMap<Language, GetByIdLanguageDto>().ReverseMap();



        }
    }
}
