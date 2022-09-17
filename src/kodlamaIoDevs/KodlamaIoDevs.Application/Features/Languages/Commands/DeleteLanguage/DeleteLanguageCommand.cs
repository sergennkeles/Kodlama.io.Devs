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

namespace KodlamaIoDevs.Application.Features.Languages.Commands.DeleteLanguage
{
 
    public class DeleteLanguageCommand : IRequest<String>
    {
        public int Id { get; set; }
    

        public class DeleteLanguageHandler : IRequestHandler<DeleteLanguageCommand, String>
        {

            private readonly ILanguageRepository _repository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _rules;

            public DeleteLanguageHandler(ILanguageRepository repository, IMapper mapper, LanguageBusinessRules rules)
            {
                _repository = repository;
                _mapper = mapper;
                _rules = rules;
            }


            public async Task<String> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
            {
                Language language = await _rules.GetLanguageAsync(request.Id);

                Language deletedLanguage = await _repository.DeleteAsync(language);
            
                return "Kayıt silindi";
            }
        }
    }
}
