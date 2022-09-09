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

namespace KodlamaIoDevs.Application.Features.Languages.Commands.DeleteLanguage
{
 
    public class DeleteLanguageCommand : IRequest<String>
    {
        public int Id { get; set; }
    

        public class DeleteLanguageHandler : IRequestHandler<DeleteLanguageCommand, String>
        {

            private readonly ILanguageRepository _repository;
            private readonly IMapper _mapper;

            public DeleteLanguageHandler(ILanguageRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }


            public async Task<String> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
            {
                Language language = _repository.Get(x => x.Id == request.Id);

                Language deletedLanguage = await _repository.DeleteAsync(language);
            
                return "Kayıt silindi";
            }
        }
    }
}
