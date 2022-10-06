using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using KodlamaIoDevs.Application.Features.Users.Dtos;
using KodlamaIoDevs.Application.Features.Users.Rules;
using KodlamaIoDevs.Application.Services.AuthService;
using KodlamaIoDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<RegisteredDto>
    {
        public UserForRegisterDto User { get; set; }
        public string IpAddress { get; set; }

        public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, RegisteredDto>
        {
            private readonly IUserRepository _repository;
            private readonly IMapper _mapper;
            private readonly IAuthService _authService;
            private readonly UserBusinessRules _rules;

            public RegisterUserHandler(IUserRepository repository, IMapper mapper, UserBusinessRules rules, IAuthService authService)
            {
                _repository = repository;
                _mapper = mapper;
                _rules = rules;
                _authService = authService;
            }



            public async Task<RegisteredDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                await _rules.CheckEmail(request.User.Email);
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

               User createdUser= await _repository.AddAsync(registerUser);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                RegisteredDto registeredDto = new()
                {
                    RefreshToken = addedRefreshToken,
                    AccessToken = createdAccessToken,
                };
                return registeredDto;

            }
        }
    }
}
