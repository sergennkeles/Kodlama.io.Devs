using FluentValidation;
using KodlamaIoDevs.Application.Features.Socials.Commands.CreateSocial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Socials.Commands.UpdateSocial
{

    public class UpdateSocialAccountValidator : AbstractValidator<UpdateSocialAccountCommand>
    {
        public UpdateSocialAccountValidator()
        {


            RuleFor(x => x.Url).NotEmpty().NotNull().MinimumLength(5).MaximumLength(30);
        }
    }
}
