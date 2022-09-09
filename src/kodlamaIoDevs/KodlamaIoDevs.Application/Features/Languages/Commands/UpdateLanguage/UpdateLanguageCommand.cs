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

namespace KodlamaIoDevs.Application.Features.Languages.Commands.UpdateLanguage
{
    
    public class UpdateLanguageCommand : IRequest<UpdateLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateLanguageHandler : IRequestHandler<UpdateLanguageCommand, UpdateLanguageDto>
        {

            private readonly ILanguageRepository _repository;
            private readonly IMapper _mapper;

            public UpdateLanguageHandler(ILanguageRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }


            public async Task<UpdateLanguageDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
            {
                Language language =  _repository.Get(x => x.Id == request.Id);
                language.Name = request.Name;
 
                Language updatedLanguage = await _repository.UpdateAsync(language);
                UpdateLanguageDto updateLanguageDto = _mapper.Map<UpdateLanguageDto>(updatedLanguage);
                return updateLanguageDto;
            }
        }
    }
}
