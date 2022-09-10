using Core.Application.Requests;
using KodlamaIoDevs.Application.Features.Languages.Queries.GetAllLanguagesWithTechnologyQuery;
using KodlamaIoDevs.Application.Features.Languages.Queries.GetByIdLanguage;
using KodlamaIoDevs.Application.Features.Technologies.Commands.CreateTechnology;
using KodlamaIoDevs.Application.Features.Technologies.Commands.DeleteTechnology;
using KodlamaIoDevs.Application.Features.Technologies.Commands.UpdateTechnology;
using KodlamaIoDevs.Application.Features.Technologies.Dtos;
using KodlamaIoDevs.Application.Features.Technologies.Models;
using KodlamaIoDevs.Application.Features.Technologies.Queries.GetAllTechnologies;
using KodlamaIoDevs.Application.Features.Technologies.Queries.GetByIdTechnology;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class TechnologiesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllList([FromQuery] PageRequest pageRequest)
        {
            GetAllTechnologyQuery getAllTechnologyQuery = new() { PageRequest = pageRequest };
            TechnologyListModel result = await Mediator.Send(getAllTechnologyQuery);
            return Ok(result);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetByIdTechnologyQuery() { Id = id });
            return Ok(result);
        }



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

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteTechnologyCommand() { Id=id});
            return Ok(result);
        }
    }
}
