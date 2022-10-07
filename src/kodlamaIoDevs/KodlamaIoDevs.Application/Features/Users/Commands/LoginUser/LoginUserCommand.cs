using AutoMapper;
using Core.Application.Pipelines.Authorization;
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

namespace KodlamaIoDevs.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginDto>
    {

        public UserForLoginDto Login { get; set; }
        public string IpAddress { get; set; }
        public class LoginUserHandler : IRequestHandler<LoginUserCommand, LoginDto>
        {

            private readonly IMapper _mapper;
            private readonly IAuthService _authService;
            private readonly UserBusinessRules _rules;
            public LoginUserHandler(IMapper mapper, UserBusinessRules rules, IAuthService authService)
            {

                _mapper = mapper;
                _rules = rules;
                _authService = authService;
            }
            public async Task<LoginDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                User userToLogin = await _rules.GetByMail(request.Login.Email);
                _rules.Verify(request.Login.Password, userToLogin.PasswordHash, userToLogin.PasswordSalt);
                AccessToken accessToken = await _authService.CreateAccessToken(userToLogin);
                RefreshToken refreshToken = await _authService.CreateRefreshToken(userToLogin, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(refreshToken);
                LoginDto tokenDto = new() { AccessToken = accessToken, RefreshToken = addedRefreshToken };
                return tokenDto;
            }
        }
    }
}
