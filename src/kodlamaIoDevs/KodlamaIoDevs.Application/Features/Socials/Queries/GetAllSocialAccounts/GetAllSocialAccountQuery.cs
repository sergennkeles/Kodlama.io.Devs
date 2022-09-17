using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.Socials.Models;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Socials.Queries.GetAllSocialAccounts
{
    public class GetAllSocialAccountQuery:IRequest<SocialAccountListModel>
    {
        public PageRequest  PageRequest { get; set; }

        public class GetAllSocialAccountQueryHandler : IRequestHandler<GetAllSocialAccountQuery, SocialAccountListModel>
        {
            private readonly ISocialRepository _repository;
            private readonly IMapper _mapper;

            public GetAllSocialAccountQueryHandler(ISocialRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<SocialAccountListModel> Handle(GetAllSocialAccountQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Social> socials = await _repository.GetListAsync(include: x => x.Include(a => a.User), index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                SocialAccountListModel model = _mapper.Map<SocialAccountListModel>(socials);
                return model;
            }
        }

    }
}
