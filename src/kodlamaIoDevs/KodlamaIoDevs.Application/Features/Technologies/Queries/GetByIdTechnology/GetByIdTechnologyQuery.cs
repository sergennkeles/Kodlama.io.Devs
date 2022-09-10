using AutoMapper;
using KodlamaIoDevs.Application.Features.Technologies.Dtos;
using KodlamaIoDevs.Application.Features.Technologies.Rules;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Technologies.Queries.GetByIdTechnology
{
    public class GetByIdTechnologyQuery:IRequest<GetByIdTechnologyDto>
    {
        public int Id { get; set; }

        public class GetByIdTechnologyQueryHandler : IRequestHandler<GetByIdTechnologyQuery, GetByIdTechnologyDto>
        {
            private readonly TechnologyBusinessRules _rules;
            private readonly IMapper _mapper;

            public GetByIdTechnologyQueryHandler(TechnologyBusinessRules rules, IMapper mapper)
            {
                _rules = rules;
                _mapper = mapper;
            }

            public async Task<GetByIdTechnologyDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
            {
                Technology technology = await _rules.GetTechnologyAsync(request.Id);
                GetByIdTechnologyDto getByIdTechnologyDto=_mapper.Map<GetByIdTechnologyDto>(technology);
                return getByIdTechnologyDto;
            }
        }
    }
}
