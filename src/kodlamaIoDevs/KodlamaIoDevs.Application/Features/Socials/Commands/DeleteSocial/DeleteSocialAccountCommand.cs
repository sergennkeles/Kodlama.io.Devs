using AutoMapper;
using KodlamaIoDevs.Application.Features.Socials.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Socials.Commands.DeleteSocial
{
    public class DeleteSocialAccountCommand:IRequest<String>
    {
        public int Id { get; set; }

        public class DeleteSocialAccountHandler : IRequestHandler<DeleteSocialAccountCommand, String>
        {
            private readonly ISocialRepository _repository;
            private readonly SocialAccountBusinessRules _rules;

            public DeleteSocialAccountHandler(ISocialRepository repository,  SocialAccountBusinessRules rules)
            {
                _repository = repository;
                _rules = rules;
            }

            async Task<string> IRequestHandler<DeleteSocialAccountCommand, string>.Handle(DeleteSocialAccountCommand request, CancellationToken cancellationToken)
            {
                Social socialAccount=await _rules.GetSocialAccountAsync(request.Id);
                Social deletedSocialAccount =await _repository.DeleteAsync(socialAccount);
                return "Kayıt silindi.";

            }
        }
    }
}
