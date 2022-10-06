using Core.Security.Entities;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Users.Dtos
{
    public class TokenDto
    {
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
