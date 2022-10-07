using Core.Security.Entities;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Services.UserService
{
    public interface IUserService
    {
        public Task<User> GetByUserIdAsync(int id);
    }
}
