using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/SchoolUser/[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;

        public AuthController(IAuthServices loginUserServices)
        {
            _authServices = loginUserServices;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            try
            {
                return Ok(await _authServices.LoginService(loginRequestDto));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(Guid Id)
        {
            try
            {
                return Ok(await _authServices.LogoutService(Id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}