using Core.Security.Dtos;
using Core.Security.Entities;
using KodlamaIoDevs.Application.Features.Languages.Commands.CreateLanguage;
using KodlamaIoDevs.Application.Features.Languages.Dtos;
using KodlamaIoDevs.Application.Features.Users.Commands.LoginUser;
using KodlamaIoDevs.Application.Features.Users.Commands.RegisterUser;
using KodlamaIoDevs.Application.Features.Users.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterUserCommand userCommand = new RegisterUserCommand()
            {
                User = userForRegisterDto,
                IpAddress = GetIpAddress()
            };

            RegisteredDto result = await Mediator.Send(userCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

       

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginUserCommand loginUserCommand = new() { Login = userForLoginDto, IpAddress = GetIpAddress() };
            LoginDto result = await Mediator.Send(loginUserCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Ok(result.AccessToken);
        }


        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }

    }
}
