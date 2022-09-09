using FluentValidation;
using KodlamaIoDevs.Application.Features.Languages.Commands.CreateLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Languages.Commands.UpdateLanguage
{
    

    public class UpdateLanguageCommandValidator : AbstractValidator<UpdateLanguageCommand>
    {
        public UpdateLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull();

        }
    }
}
