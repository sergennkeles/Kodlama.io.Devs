using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.UserOperationClaims.Dtos
{
    public class GetUserOperationClaimByIdDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public int  OperationClaimId { get; set; }

        public string ClaimName { get; set; }


    }
}
