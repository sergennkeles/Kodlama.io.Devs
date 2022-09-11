using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Services.Repositories
{
    public interface IUserRepository:IAsyncRepository<User>,IRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
