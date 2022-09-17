using Core.CrossCuttingConcerns.Exceptions;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Socials.Rules
{
    public class SocialAccountBusinessRules
    {
        private readonly ISocialRepository _repository;

        public SocialAccountBusinessRules(ISocialRepository repository)
        {
            _repository = repository;
        }

        public async Task<Social> GetSocialAccountAsync(int id)
        {
            Social social = await _repository.GetAsync(x => x.Id == id);
            if (social == null) throw new BusinessException("Böyle bir hesap  yok.");
            return social;
        }
    }
}
