using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Services.OperationClaimService
{
    public interface IOperationClaimService
    {
        Task<OperationClaim> GetOperationClaimByIdAsync(int id);
    }
}
