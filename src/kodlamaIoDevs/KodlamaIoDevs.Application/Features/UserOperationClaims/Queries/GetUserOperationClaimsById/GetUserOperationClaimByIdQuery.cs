using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using KodlamaIoDevs.Application.Features.UserOperationClaims.Dtos;
using KodlamaIoDevs.Application.Features.UserOperationClaims.Models;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.UserOperationClaims.Queries.GetUserOperationClaimsById
{
    public class GetUserOperationClaimByIdQuery:IRequest<UserOperationClaimListModel>
    {
        public int UserId { get; set; }

        public class GetUserOperationClaimByIdQueryHandler : IRequestHandler<GetUserOperationClaimByIdQuery, UserOperationClaimListModel>
        {
            private readonly IUserOperationClaimRepository _repository;
            private readonly IMapper _mapper;

            public GetUserOperationClaimByIdQueryHandler(IUserOperationClaimRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<UserOperationClaimListModel> Handle(GetUserOperationClaimByIdQuery request, CancellationToken cancellationToken)
            {
               IPaginate<UserOperationClaim> userOperationClaim=await _repository.GetListAsync(x=>x.UserId==request.UserId,include:u=>u.Include(a=>a.User).Include(b=>b.OperationClaim));
           
                UserOperationClaimListModel userOperationClaimListModel = _mapper.Map<UserOperationClaimListModel>(userOperationClaim);


                return userOperationClaimListModel;
            }

       
        }
    }
}
