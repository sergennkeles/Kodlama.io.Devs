using AutoMapper;
using Core.Security.Entities;
using KodlamaIoDevs.Application.Features.UserOperationClaims.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommand:IRequest<String>
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public class CreateUserOperationClaimHandler : IRequestHandler<CreateUserOperationClaimCommand, String>
        {
            private readonly IUserOperationClaimRepository _repository;
            private readonly UserOperationClaimBusinessRules _rules;
            private readonly IMapper _mapper;

            public CreateUserOperationClaimHandler(UserOperationClaimBusinessRules rules, IUserOperationClaimRepository repository, IMapper mapper)
            {
                _rules = rules;
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<string> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            { 
               
                await _rules.GetByOperationClaimId(request.OperationClaimId);
                await _rules.GetByUserId(request.UserId);
                UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(request);
                await _repository.AddAsync(userOperationClaim);
                return "Kullanıcıya claim tanımlandı.";

            }
        }
    }
}
