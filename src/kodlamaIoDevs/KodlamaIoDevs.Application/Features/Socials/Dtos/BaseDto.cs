using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Socials.Dtos
{
    public class BaseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Url { get; set; }
    }
}
