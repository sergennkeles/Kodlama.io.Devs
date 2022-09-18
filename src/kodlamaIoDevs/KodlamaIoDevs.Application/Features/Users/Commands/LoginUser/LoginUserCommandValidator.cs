using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandValidator:AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x=>x.Login.Email).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(x=>x.Login.Password).NotEmpty().MinimumLength(4);

        }
    }
}
