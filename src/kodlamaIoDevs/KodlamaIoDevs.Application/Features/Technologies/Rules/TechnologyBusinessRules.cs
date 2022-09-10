using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _repository;

        public TechnologyBusinessRules(ITechnologyRepository repository)
        {
            _repository = repository;
        }

        public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Technology> result = await _repository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Aynı isimde teknoloji var.");
        }

        public async Task<Technology> GetTechnologyAsync(int id)
        {
            Technology technology = await _repository.GetAsync(x => x.Id == id);
            if (technology == null) throw new BusinessException("Böyle bir teknoloji ismi yok.");
            return technology;
        }
    }
}
