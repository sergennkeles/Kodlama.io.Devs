using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _repository;

        public OperationClaimBusinessRules(IOperationClaimRepository repository)
        {
            _repository = repository;
        }

        public async Task OperationClaimNameCanNotBeDublicatedWhenInserted(string name)
        {

            IPaginate<OperationClaim> result = await _repository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Bu isimde claim  zaten var.");
        }

        public async Task<OperationClaim> GetOperationClaimAsync(int id)
        {
            OperationClaim claim = await _repository.GetAsync(x => x.Id == id);
            if (claim == null) throw new BusinessException("Böyle bir claim yok.");
            return claim;
        }
    }
}
