using Core.Application.Requests;
using KodlamaIoDevs.Application.Features.Languages.Commands.CreateLanguage;
using KodlamaIoDevs.Application.Features.Languages.Commands.DeleteLanguage;
using KodlamaIoDevs.Application.Features.Languages.Commands.UpdateLanguage;
using KodlamaIoDevs.Application.Features.Languages.Dtos;
using KodlamaIoDevs.Application.Features.Languages.Models;
using KodlamaIoDevs.Application.Features.Languages.Queries.GetAllLangues;
using KodlamaIoDevs.Application.Features.Socials.Commands.CreateSocial;
using KodlamaIoDevs.Application.Features.Socials.Commands.DeleteSocial;
using KodlamaIoDevs.Application.Features.Socials.Commands.UpdateSocial;
using KodlamaIoDevs.Application.Features.Socials.Dtos;
using KodlamaIoDevs.Application.Features.Socials.Models;
using KodlamaIoDevs.Application.Features.Socials.Queries.GetAllSocialAccounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
  
    public class SocialsController : BaseController
    {
        [HttpPost]

        public async Task<IActionResult> Add([FromBody] CreateSocialAccountCommand createSocialCommand)
        {
            CreateSocialAccountDto result = await Mediator.Send(createSocialCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSocialAccountCommand updateSocialAccountCommand)
        {
            UpdateSocialAccountDto result = await Mediator.Send(updateSocialAccountCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteSocialAccountCommand() { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllList([FromQuery] PageRequest pageRequest)
        {
            GetAllSocialAccountQuery getAllSocialAccountQuery = new() { PageRequest = pageRequest };
            SocialAccountListModel result = await Mediator.Send(getAllSocialAccountQuery);
            return Ok(result);
        }
    }
}
