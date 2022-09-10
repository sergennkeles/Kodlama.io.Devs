using AutoMapper;
using KodlamaIoDevs.Application.Features.Languages.Dtos;
using KodlamaIoDevs.Application.Features.Languages.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Languages.Queries.GetByIdLanguage
{
    public class GetByIdLanguageQuery : IRequest<GetByIdLanguageDto>
    {
        public int Id { get; set; }
        public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQuery, GetByIdLanguageDto>
        {


            private readonly LanguageBusinessRules _rules;
            private readonly IMapper _mapper;

            public GetByIdLanguageQueryHandler(ILanguageRepository repository, IMapper mapper, LanguageBusinessRules rules)
            {

                _mapper = mapper;
                _rules = rules;
            }

            public async Task<GetByIdLanguageDto> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
            {
                Language language = await _rules.GetLanguageAsync(request.Id);
                GetByIdLanguageDto languageDto = _mapper.Map<GetByIdLanguageDto>(language);
                return languageDto;
            }
        }
    }
}
