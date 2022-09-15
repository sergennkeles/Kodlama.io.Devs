using KodlamaIoDevs.Application.Features.Languages.Commands.CreateLanguage;
using KodlamaIoDevs.Application.Features.Languages.Dtos;
using KodlamaIoDevs.Application.Features.Socials.Commands.CreateSocial;
using KodlamaIoDevs.Application.Features.Socials.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
  
    public class SocialsController : BaseController
    {
        [HttpPost]

        public async Task<IActionResult> Add([FromBody] CreateSocialCommand createSocialCommand)
        {
            CreateSocialDto result = await Mediator.Send(createSocialCommand);
            return Created("", result);
        }
    }
}
