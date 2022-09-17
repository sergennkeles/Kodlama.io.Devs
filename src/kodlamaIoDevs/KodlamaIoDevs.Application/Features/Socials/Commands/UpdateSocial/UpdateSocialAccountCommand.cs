using AutoMapper;
using KodlamaIoDevs.Application.Features.Socials.Dtos;
using KodlamaIoDevs.Application.Features.Socials.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Socials.Commands.UpdateSocial
{
    public class UpdateSocialAccountCommand:IRequest<UpdateSocialAccountDto>
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public class UpdateSocialAccountHandler : IRequestHandler<UpdateSocialAccountCommand, UpdateSocialAccountDto>
        {
            private readonly IMapper _mapper;
            private readonly SocialAccountBusinessRules _rules;
            private readonly ISocialRepository _repository;
            public UpdateSocialAccountHandler(IMapper mapper, SocialAccountBusinessRules rules, ISocialRepository repository)
            {
                _mapper = mapper;
                _rules = rules;
                _repository = repository;
            }

            public async Task<UpdateSocialAccountDto> Handle(UpdateSocialAccountCommand request, CancellationToken cancellationToken)
            {
                Social socialAccount=await _rules.GetSocialAccountAsync(request.Id);
                socialAccount.Url = request.Url;
                Social updatedSocialAccount = await _repository.UpdateAsync(socialAccount);
                UpdateSocialAccountDto socialAccountDto =_mapper.Map<UpdateSocialAccountDto>(socialAccount);
                return socialAccountDto;
            }
        }
    }
}
