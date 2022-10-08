using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.Languages.Dtos;
using KodlamaIoDevs.Application.Features.UserOperationClaims.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.UserOperationClaims.Models
{
    public class UserOperationClaimListModel:BasePageableModel
    {
        public IList<GetUserOperationClaimByIdDto> Items { get; set; }
    }
}
