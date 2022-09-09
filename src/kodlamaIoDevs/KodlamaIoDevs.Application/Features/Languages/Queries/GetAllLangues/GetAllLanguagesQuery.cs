using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.Languages.Models;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Languages.Queries.GetAllLangues
{
    public class GetAllLanguagesQuery : IRequest<LanguageListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllLanguageQueryHandler : IRequestHandler<GetAllLanguagesQuery, LanguageListModel>
        {
            private readonly ILanguageRepository _repository;
            private readonly IMapper _mapper;

            public GetAllLanguageQueryHandler(ILanguageRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<LanguageListModel> Handle(GetAllLanguagesQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Language> languages = await _repository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                LanguageListModel languageListModel = _mapper.Map<LanguageListModel>(languages);
                return languageListModel;
            }
        }
    }
}
