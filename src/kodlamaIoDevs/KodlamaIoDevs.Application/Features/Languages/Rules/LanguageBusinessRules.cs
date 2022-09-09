using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Languages.Rules
{
    public class LanguageBusinessRules
    {
        private readonly ILanguageRepository _repository;

        public LanguageBusinessRules(ILanguageRepository repository)
        {
            _repository = repository;
        }

        public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Language> result = await _repository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Aynı isimde programlama dili var.");
        }

        public async Task<Language> GetLanguageAsync(int id)
        {
            Language language = await _repository.GetAsync(x => x.Id == id);
            if (language==null) throw new BusinessException("Böyle bir programlama dili yok.");
            return language;
        }

    }
}
