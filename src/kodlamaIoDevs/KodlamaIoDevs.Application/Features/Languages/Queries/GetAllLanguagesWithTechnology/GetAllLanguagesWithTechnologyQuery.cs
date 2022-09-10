using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.Languages.Models;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Languages.Queries.GetAllLanguagesWithTechnologyQuery
{
    public class GetAllLanguagesWithTechnologyQuery : IRequest<LanguageListWithTechnologyModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllLanguagesWithTechnologyQueryHandler : IRequestHandler<GetAllLanguagesWithTechnologyQuery, LanguageListWithTechnologyModel>
        {
            private readonly ILanguageRepository _repository;
            private readonly IMapper _mapper;

            public GetAllLanguagesWithTechnologyQueryHandler(ILanguageRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<LanguageListWithTechnologyModel> Handle(GetAllLanguagesWithTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Language> languages = await _repository.GetListAsync(include: x => x.Include(a => a.Technologies), index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                LanguageListWithTechnologyModel languageListModel = _mapper.Map<LanguageListWithTechnologyModel>(languages);
                return languageListModel;
            }
        }

    }
}
