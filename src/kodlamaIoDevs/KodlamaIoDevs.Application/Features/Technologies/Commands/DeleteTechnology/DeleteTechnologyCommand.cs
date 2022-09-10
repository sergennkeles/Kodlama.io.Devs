using KodlamaIoDevs.Application.Features.Technologies.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand:IRequest<String>
    {
        public int Id { get; set; }

        public class DeleteTechnologyHandler : IRequestHandler<DeleteTechnologyCommand, String>
        {
            private readonly ITechnologyRepository _repository;
            private readonly TechnologyBusinessRules _rules;

            public DeleteTechnologyHandler(ITechnologyRepository repository, TechnologyBusinessRules rules)
            {
                _repository = repository;
                _rules = rules;
            }

            public async Task<string> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology technology = await _rules.GetTechnologyAsync(request.Id);
                await _repository.DeleteAsync(technology);
                return "Kayıt silindi.";
            }
        }
    }
}
