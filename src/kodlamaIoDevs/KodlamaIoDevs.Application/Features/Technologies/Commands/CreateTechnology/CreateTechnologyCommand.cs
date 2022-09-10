using AutoMapper;
using KodlamaIoDevs.Application.Features.Technologies.Dtos;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommand : IRequest<CreateTechnologyDto>
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }

        public class CreateTechnologyHandler : IRequestHandler<CreateTechnologyCommand, CreateTechnologyDto>
        {

            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _repository;

            public CreateTechnologyHandler(IMapper mapper, ITechnologyRepository repository)
            {
                _mapper = mapper;
                _repository = repository;
            }



            public async Task<CreateTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology mappedTechnology= _mapper.Map<Technology>(request);
                Technology technology = await _repository.AddAsync(mappedTechnology);
                CreateTechnologyDto technologyDto=_mapper.Map<CreateTechnologyDto>(technology);
                return technologyDto;

            }
        }
    }
}
