using AutoMapper;
using KodlamaIoDevs.Application.Features.Languages.Dtos;
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
    public class CreateLanguageCommand:IRequest<CreateLanguageDto>
    {
        public string? Name { get; set; }

        public class CreateLanguageHandler : IRequestHandler<CreateLanguageCommand, CreateLanguageDto>
        {

            private readonly ILanguageRepository _repository;
            private readonly IMapper _mapper;

            public CreateLanguageHandler(ILanguageRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }


            public async Task<CreateLanguageDto> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
            {
                Language mappedLanguage=_mapper.Map<Language>(request);
                Language createLanguage = await _repository.AddAsync(mappedLanguage);
                CreateLanguageDto createLanguageDto = _mapper.Map<CreateLanguageDto>(createLanguage);
                return createLanguageDto;
            }
        }
    }
}
