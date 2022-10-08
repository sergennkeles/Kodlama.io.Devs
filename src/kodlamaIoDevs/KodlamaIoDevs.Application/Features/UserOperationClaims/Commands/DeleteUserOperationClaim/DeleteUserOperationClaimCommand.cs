using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using KodlamaIoDevs.Application.Features.UserOperationClaims.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommand:IRequest<String>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new String[] { "Admin" };

        public class DeleteUserOperationClaimHandler : IRequestHandler<DeleteUserOperationClaimCommand, String>
        {
            private readonly UserOperationClaimBusinessRules _rules;
            private readonly IUserOperationClaimRepository _repository;
            public DeleteUserOperationClaimHandler(UserOperationClaimBusinessRules rules, IUserOperationClaimRepository repository)
            {
                _rules = rules;
                _repository = repository;
            }

            public async Task<string> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim claim = await _rules.GetByUserOperationClaim(request.Id);
                await _repository.DeleteAsync(claim);
                return "Kayıt silindi";
            }
        }
    }
}
