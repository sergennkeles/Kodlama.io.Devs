using Core.Security.Entities;
using KodlamaIoDevs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Services.UserService
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _repository;

        public UserManager(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> GetByUserIdAsync(int id)
        {
            User user= await _repository.GetAsync(x=>x.Id == id);
            return user;
        }
    }
}
