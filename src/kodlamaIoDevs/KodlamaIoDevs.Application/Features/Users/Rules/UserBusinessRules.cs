using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using KodlamaIoDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _repository;
        private readonly ITokenHelper _tokenHelper;

        public UserBusinessRules(IUserRepository repository, ITokenHelper tokenHelper)
        {
            _repository = repository;
            _tokenHelper = tokenHelper;
        }

        public async Task<User> GetByMail (string email)
        {
            var user= await _repository.GetAsync(a => a.Email == email);
            if (user==null)
            {
                throw new BusinessException("Böyle bir kullanıcı yok!");
            }
            return user;
        }

        public bool Verify (string password, byte[] passwordHash, byte[]passwordSalt)
        {
            if (!HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt))
            {
                throw new BusinessException("Böyle bir kullanıcı yok!");
            }

            return true;
        }
         


        public AccessToken CreateAccessToken(User user)
        {
            var claims = _repository.GetClaims(user);
            AccessToken token = _tokenHelper.CreateToken(user, claims);
            return token;

        }

    }
}
