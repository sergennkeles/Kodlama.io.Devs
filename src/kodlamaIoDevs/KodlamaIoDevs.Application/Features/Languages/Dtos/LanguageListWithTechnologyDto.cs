using KodlamaIoDevs.Domain.Entities;

namespace KodlamaIoDevs.Application.Features.Languages.Dtos
{
    public class LanguageListWithTechnologyDto:BaseDto
    {
        public  IList<string> TechnologyName { get; set; }
    }
}
