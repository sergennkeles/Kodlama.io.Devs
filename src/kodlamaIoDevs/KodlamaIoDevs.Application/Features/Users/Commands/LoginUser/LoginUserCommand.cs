using AutoMapper;
using Core.Application.Pipelines.Authorization;
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

namespace KodlamaIoDevs.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<TokenDto>
    {
     
        public UserForLoginDto Login { get; set; }

        public class LoginUserHandler : IRequestHandler<LoginUserCommand, TokenDto>
        {

            private readonly IMapper _mapper;
            private readonly UserBusinessRules _rules;
            public LoginUserHandler(IMapper mapper, UserBusinessRules rules)
            {

                _mapper = mapper;
                _rules = rules;
            }
            public async Task<TokenDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                User userToLogin = await _rules.GetByMail(request.Login.Email);
                var verifyPassword = _rules.Verify(request.Login.Password, userToLogin.PasswordHash, userToLogin.PasswordSalt);
                var token = _rules.CreateAccessToken(userToLogin);
                TokenDto tokenDto = _mapper.Map<TokenDto>(token);
                return tokenDto;
            }
        }
    }
}
