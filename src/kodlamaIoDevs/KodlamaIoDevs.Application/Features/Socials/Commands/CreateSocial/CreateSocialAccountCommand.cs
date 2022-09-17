using AutoMapper;
using KodlamaIoDevs.Application.Features.Socials.Dtos;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Socials.Commands.CreateSocial
{
    public class CreateSocialAccountCommand:IRequest<CreateSocialAccountDto>
    {
        public int UserId { get; set; }
        public string Url { get; set; }

        public class CreateSocialHandler : IRequestHandler<CreateSocialAccountCommand, CreateSocialAccountDto>
        {
            private readonly IMapper _mapper;
            private readonly ISocialRepository _repository;

            public CreateSocialHandler(IMapper mapper, ISocialRepository repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<CreateSocialAccountDto> Handle(CreateSocialAccountCommand request, CancellationToken cancellationToken)
            {
                Social mappedSocial= _mapper.Map<Social>(request);
                Social social = await _repository.AddAsync(mappedSocial);
                CreateSocialAccountDto createSocialDto=_mapper.Map<CreateSocialAccountDto>(social);
                return createSocialDto;
            }
        }
    }
}
