using KodlamaIoDevs.Application.Features.Languages.Commands.CreateLanguage;
using KodlamaIoDevs.Application.Features.Languages.Dtos;
using KodlamaIoDevs.Application.Features.Users.Commands.LoginUser;
using KodlamaIoDevs.Application.Features.Users.Commands.RegisterUser;
using KodlamaIoDevs.Application.Features.Users.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AuthController:BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
           
            TokenDto result = await Mediator.Send(registerUserCommand);
            return Created("", result.AccessToken);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
        {

            TokenDto result = await Mediator.Send(loginUserCommand);
            return Ok(result);
        }
    }
}
