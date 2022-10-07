using AutoMapper;
using Core.Security.Entities;
using KodlamaIoDevs.Application.Features.OperationClaims.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommand:IRequest<String>
    {
        public int Id { get; set; }

        public class DeleteOperationClaimHandler : IRequestHandler<DeleteOperationClaimCommand, String>
        {
            private readonly IOperationClaimRepository _repository;
            private readonly OperationClaimBusinessRules _rules;

            public DeleteOperationClaimHandler(IOperationClaimRepository repository, OperationClaimBusinessRules rules)
            {
                _repository = repository;
                _rules = rules;
            }
            public async Task<string> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim getClaim = await _rules.GetOperationClaimAsync(request.Id);
                await _repository.DeleteAsync(getClaim);

                return "Kayıt silindi";
            }
        }
    }
}
