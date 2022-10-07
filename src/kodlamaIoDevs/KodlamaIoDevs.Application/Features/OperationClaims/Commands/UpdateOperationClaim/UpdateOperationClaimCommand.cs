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

namespace KodlamaIoDevs.Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommand:IRequest<UpdatedOperationClaimDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateOperationClaimHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _repository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _rules;

            public UpdateOperationClaimHandler(IOperationClaimRepository repository, IMapper mapper, OperationClaimBusinessRules rules)
            {
                _repository = repository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim getClaim = await _rules.GetOperationClaimAsync(request.Id);
                getClaim.Name=request.Name; 
                OperationClaim updatedClaim= await _repository.UpdateAsync(getClaim);
                UpdatedOperationClaimDto claimDto=_mapper.Map<UpdatedOperationClaimDto>(updatedClaim);  
                return claimDto;

            }
        }
    }
}
