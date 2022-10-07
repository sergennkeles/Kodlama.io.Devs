using Core.Security.Entities;
using KodlamaIoDevs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Services.OperationClaimService
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimRepository _repository;

        public OperationClaimManager(IOperationClaimRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationClaim> GetOperationClaimByIdAsync(int id)
        {
            OperationClaim claim = await _repository.GetAsync(x => x.Id==id);
            return claim;
        }
    }
}
