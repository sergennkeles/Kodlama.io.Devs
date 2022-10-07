using AutoMapper;
using Core.Security.Entities;
using KodlamaIoDevs.Application.Features.OperationClaims.Dtos;
using KodlamaIoDevs.Application.Features.OperationClaims.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommand:IRequest<CreatedOperationClaimDto>
    {

        public string Name { get; set; }

        public class CreateOperationClaimHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _repository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _rules;

            public CreateOperationClaimHandler(IOperationClaimRepository repository, IMapper mapper, OperationClaimBusinessRules rules)
            {
                _repository = repository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _rules.OperationClaimNameCanNotBeDublicatedWhenInserted(request.Name);
                OperationClaim mappedClaim=_mapper.Map<OperationClaim>(request);
                OperationClaim createdClaim= await _repository.AddAsync(mappedClaim); 
                CreatedOperationClaimDto claimDto=_mapper.Map<CreatedOperationClaimDto>(createdClaim); ;
                return claimDto;

            }
        }
    }
}
