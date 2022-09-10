using AutoMapper;
using KodlamaIoDevs.Application.Features.Technologies.Commands.CreateTechnology;
using KodlamaIoDevs.Application.Features.Technologies.Dtos;
using KodlamaIoDevs.Application.Features.Technologies.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand:IRequest<UpdateTechnologyDto>
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }

        public class UpdateTechnologyHandler : IRequestHandler<UpdateTechnologyCommand, UpdateTechnologyDto>
        {

            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _repository;
            private readonly TechnologyBusinessRules _rules;
            public UpdateTechnologyHandler(IMapper mapper, ITechnologyRepository repository, TechnologyBusinessRules rules)
            {
                _mapper = mapper;
                _repository = repository;
                _rules = rules;
            }



            public async Task<UpdateTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology findTechnology = await _rules.GetTechnologyAsync(request.Id);
                findTechnology.LanguageId = request.LanguageId;
                findTechnology.Name=request.Name;
                Technology technology = await _repository.UpdateAsync(findTechnology);
                UpdateTechnologyDto technologyDto = _mapper.Map<UpdateTechnologyDto>(technology);
                return technologyDto;

            }
        }
    }
}
