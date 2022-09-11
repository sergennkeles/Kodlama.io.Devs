using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using KodlamaIoDevs.Application.Features.Users.Dtos;
using KodlamaIoDevs.Application.Features.Users.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<TokenDto>
    {
        public UserForRegisterDto User { get; set; }

        public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, TokenDto>
        {
            private readonly IUserRepository _repository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _rules;
         
            public RegisterUserHandler(IUserRepository repository, IMapper mapper, UserBusinessRules rules)
            {
                _repository = repository;
                _mapper = mapper;
                _rules = rules;
            }



            public async Task<TokenDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.User.Password, out passwordHash, out passwordSalt);

                User registerUser = new User()
                {
                    FirstName = request.User.FirstName,
                    LastName = request.User.LastName,
                    Email = request.User.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status=true,          
                };

               var token= _rules.CreateAccessToken(registerUser);
                await _repository.AddAsync(registerUser);
                TokenDto tokenDto=_mapper.Map<TokenDto>(token);
                return tokenDto;
                
            }
        }
    }
}
