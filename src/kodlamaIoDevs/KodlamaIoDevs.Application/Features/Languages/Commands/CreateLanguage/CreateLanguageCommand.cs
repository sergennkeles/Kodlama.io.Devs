using AutoMapper;
using Core.Application.Pipelines.Authorization;
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

namespace KodlamaIoDevs.Application.Features.Languages.Commands.CreateLanguage
{
    public class CreateLanguageCommand:IRequest<CreateLanguageDto>, ISecuredRequest
    {
        public string? Name { get; set; }

        public string[] Roles => new String[] {"admin" };

        public class CreateLanguageHandler : IRequestHandler<CreateLanguageCommand, CreateLanguageDto>
        {

            private readonly ILanguageRepository _repository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _rules;

            public CreateLanguageHandler(ILanguageRepository repository, IMapper mapper, LanguageBusinessRules rules)
            {
                _repository = repository;
                _mapper = mapper;
                _rules = rules;
            }


            public async Task<CreateLanguageDto> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
            {
                await _rules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                Language mappedLanguage=_mapper.Map<Language>(request);
                Language createLanguage = await _repository.AddAsync(mappedLanguage);
                CreateLanguageDto createLanguageDto = _mapper.Map<CreateLanguageDto>(createLanguage);
                return createLanguageDto;
            }
        }
    }
}
