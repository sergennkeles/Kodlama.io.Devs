using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.Languages.Dtos;
using KodlamaIoDevs.Application.Features.Socials.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Socials.Models
{
    public class SocialAccountListModel: BasePageableModel
    {
        public IList<SocialAccountListDto>? Items { get; set; }
    }
    
}
