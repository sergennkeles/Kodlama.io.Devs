using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using KodlamaIoDevs.Application.Features.Languages.Models;
using KodlamaIoDevs.Application.Features.OperationClaims.Models;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.OperationClaims.Queries.GetAllClaims
{
    public class GetAllOperationClaimsQuery:IRequest<OperationClaimListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllOperationClaimsQueryHandler : IRequestHandler<GetAllOperationClaimsQuery, OperationClaimListModel>
        {
            private readonly IOperationClaimRepository _repository;
            private readonly IMapper _mapper;

            public GetAllOperationClaimsQueryHandler(IOperationClaimRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<OperationClaimListModel> Handle(GetAllOperationClaimsQuery request, CancellationToken cancellationToken)
            {
                IPaginate<OperationClaim> claims = await _repository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                OperationClaimListModel claimListModel = _mapper.Map<OperationClaimListModel>(claims);
                return claimListModel;
            }
        }
    }
}
