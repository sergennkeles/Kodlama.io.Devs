using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Socials.Commands.CreateSocial
{
    public class CreateSocialAccountCommandValidator:AbstractValidator<CreateSocialAccountCommand>
    {
        public CreateSocialAccountCommandValidator()
        {

            RuleFor(x=>x.UserId).NotEmpty();
            RuleFor(x=>x.Url).NotEmpty().NotNull().MinimumLength(5).MaximumLength(30);
        }
    }
}
