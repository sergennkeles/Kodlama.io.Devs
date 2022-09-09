using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.Languages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Languages.Models
{
    public class LanguageListModel: BasePageableModel
    {
        public IList<LanguageListDto>? Items { get; set; }
    }
}
