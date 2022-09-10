using KodlamaIoDevs.Application.Features.Languages.Commands.CreateLanguage;
using KodlamaIoDevs.Application.Features.Languages.Commands.UpdateLanguage;
using KodlamaIoDevs.Application.Features.Languages.Dtos;
using KodlamaIoDevs.Application.Features.Technologies.Commands.CreateTechnology;
using KodlamaIoDevs.Application.Features.Technologies.Commands.UpdateTechnology;
using KodlamaIoDevs.Application.Features.Technologies.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class TechnologiesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            CreateTechnologyDto result = await Mediator.Send(createTechnologyCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            UpdateTechnologyDto result = await Mediator.Send(updateTechnologyCommand);
            return Ok(result);
        }
    }
}
