using Core.Application.Requests;
using KodlamaIoDevs.Application.Features.Languages.Commands.CreateLanguage;
using KodlamaIoDevs.Application.Features.Languages.Commands.DeleteLanguage;
using KodlamaIoDevs.Application.Features.Languages.Commands.UpdateLanguage;
using KodlamaIoDevs.Application.Features.Languages.Dtos;
using KodlamaIoDevs.Application.Features.Languages.Models;
using KodlamaIoDevs.Application.Features.Languages.Queries.GetAllLanguagesWithTechnologyQuery;
using KodlamaIoDevs.Application.Features.Languages.Queries.GetAllLangues;
using KodlamaIoDevs.Application.Features.Languages.Queries.GetByIdLanguage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebAPI.Controllers
{
    public class LanguagesController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAllList([FromQuery] PageRequest pageRequest)
        {
            GetAllLanguagesQuery getAllLanguageQuery = new() { PageRequest = pageRequest };
            LanguageListModel result = await Mediator.Send(getAllLanguageQuery);
            return Ok(result);
        }

        [HttpGet("getAllTLanguagesWithTechnology")]
        public async Task<IActionResult> GetAllLanguagesWithTechnology([FromQuery] PageRequest pageRequest)
        {
            GetAllLanguagesWithTechnologyQuery getAllTechnologyQuery = new() { PageRequest = pageRequest };
            LanguageListWithTechnologyModel result = await Mediator.Send(getAllTechnologyQuery);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetByIdLanguageQuery() { Id = id });
            return Ok(result);
        }

        [HttpPost,Authorize]
    
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
        {
            CreateLanguageDto result = await Mediator.Send(createLanguageCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageCommand updateLanguageCommand)
        {
            UpdateLanguageDto result = await Mediator.Send(updateLanguageCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteLanguageCommand() { Id=id});
            return Ok(result);
        }

       
    }
}
