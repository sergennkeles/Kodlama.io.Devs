using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommandValidator:AbstractValidator<CreateTechnologyCommand>
    {
        public CreateTechnologyCommandValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().NotNull().MinimumLength(3);
         
        }
    }
}
