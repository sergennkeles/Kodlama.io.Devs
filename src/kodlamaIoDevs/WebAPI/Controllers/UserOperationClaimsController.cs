using KodlamaIoDevs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using KodlamaIoDevs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using KodlamaIoDevs.Application.Features.OperationClaims.Dtos;
using KodlamaIoDevs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using KodlamaIoDevs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
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
    }
}
