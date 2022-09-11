using Core.Persistence.Repositories;
using Core.Security.Entities;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
    {
        private readonly BaseDbContext _context;
        public UserRepository(BaseDbContext context) : base(context)
        {
            _context = context; 
        }

        public List<OperationClaim> GetClaims(User user)
        {
           
                var result = from operationClaim in _context.OperationClaims
                             join userOperationClaim in _context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return result.ToList();
            }
       
    }
}
