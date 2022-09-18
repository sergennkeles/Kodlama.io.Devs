using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandValidator:AbstractValidator<RegisterUserCommand>    
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x=>x.User.Email).NotEmpty().NotNull().MinimumLength(3).MaximumLength(30).EmailAddress();
            RuleFor(x=>x.User.FirstName).NotEmpty().NotNull().MinimumLength(3).MaximumLength(30);
            RuleFor(x=>x.User.LastName).NotEmpty().NotNull().MinimumLength(3).MaximumLength(30);
            RuleFor(x=>x.User.Password).NotEmpty().NotNull().MinimumLength(3).MaximumLength(30);
        }
    }
}
