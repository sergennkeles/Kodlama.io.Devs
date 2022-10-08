using Core.Application.Requests;
using KodlamaIoDevs.Application.Features.Languages.Queries.GetByIdLanguage;
using KodlamaIoDevs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using KodlamaIoDevs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using KodlamaIoDevs.Application.Features.OperationClaims.Dtos;
using KodlamaIoDevs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using KodlamaIoDevs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using KodlamaIoDevs.Application.Features.UserOperationClaims.Queries.GetUserOperationClaimsById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
 
    public class UserOperationClaimsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            String result = await Mediator.Send(createUserOperationClaimCommand);
            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteUserOperationClaimCommand() { Id = id });
            return Ok(result);
        }

        

        [HttpGet("id")]
        public async Task<IActionResult> GetUserOperationClaimById(int userId)
        {
            GetUserOperationClaimByIdQuery query = new GetUserOperationClaimByIdQuery() { UserId= userId };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

    }
}
