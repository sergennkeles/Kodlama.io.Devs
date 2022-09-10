using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.Technologies.Models;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Technologies.Queries.GetAllTechnologies
{
    public class GetAllTechnologyQuery:IRequest<TechnologyListModel>
    {
        public PageRequest  PageRequest { get; set; }

        public class GetAllTechnologyQueryHandler : IRequestHandler<GetAllTechnologyQuery, TechnologyListModel>
        {

            private readonly ITechnologyRepository _repository;
            private readonly IMapper _mapper;

            public GetAllTechnologyQueryHandler(ITechnologyRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<TechnologyListModel> Handle(GetAllTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Technology> paginate = await _repository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                TechnologyListModel technologyList=_mapper.Map<TechnologyListModel>(paginate);
                return technologyList;
            }
        }
    }
}
