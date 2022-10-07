using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.Languages.Dtos;
using KodlamaIoDevs.Application.Features.OperationClaims.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.OperationClaims.Models
{
   
    public class OperationClaimListModel : BasePageableModel
    {
        public IList<OperationClaimListDto>? Items { get; set; }
    }
}
