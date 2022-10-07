﻿using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using KodlamaIoDevs.Application.Services.OperationClaimService;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Application.Services.UserService;
using KodlamaIoDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserOperationClaimRepository _repository;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IUserService _userService;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository repository, IOperationClaimService operationClaimService, IUserService userService)
        {
            _repository = repository;
            _operationClaimService = operationClaimService;
            _userService = userService;
        }

        public async Task GetByUserId(int id)
        {
            var user=  await _userService.GetByUserIdAsync(id);
            if (user == null) throw new BusinessException("Böyle bir kullanıcı yok.");
           
        }

        public async Task GetByOperationClaimId(int id)
        {
           var operationClaim=  await _userService.GetByUserIdAsync(id);
            if (operationClaim == null) throw new BusinessException("Böyle bir claim yok.");

        }
    }
}