using Core.Application.Requests;
using KodlamaIoDevs.Application.Features.Languages.Commands.CreateLanguage;
using KodlamaIoDevs.Application.Features.Languages.Commands.DeleteLanguage;
using KodlamaIoDevs.Application.Features.Languages.Commands.UpdateLanguage;
using KodlamaIoDevs.Application.Features.Languages.Dtos;
using KodlamaIoDevs.Application.Features.Languages.Models;
using KodlamaIoDevs.Application.Features.Languages.Queries.GetAllLangues;
using KodlamaIoDevs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using KodlamaIoDevs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using KodlamaIoDevs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using KodlamaIoDevs.Application.Features.OperationClaims.Dtos;
using KodlamaIoDevs.Application.Features.OperationClaims.Models;
using KodlamaIoDevs.Application.Features.OperationClaims.Queries.GetAllClaims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    public class OperationClaimsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllList([FromQuery] PageRequest pageRequest)
        {
            GetAllOperationClaimsQuery getAllOperationClaimsQuery = new() { PageRequest = pageRequest };
            OperationClaimListModel result = await Mediator.Send(getAllOperationClaimsQuery);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
        {
            CreatedOperationClaimDto result = await Mediator.Send(createOperationClaimCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
        {
            UpdatedOperationClaimDto result = await Mediator.Send(updateOperationClaimCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteOperationClaimCommand() { Id = id });
            return Ok(result);
        }
    }
}
