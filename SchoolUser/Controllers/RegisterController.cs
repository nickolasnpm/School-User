using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/SchoolUser/[Controller]")]
    [Authorize(Roles = "Admin")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterServices _registerServices;
        private readonly IHeaderServices _headerServices;

        public RegisterController(IRegisterServices registerServices, IHeaderServices headerServices)
        {
            _registerServices = registerServices;
            _headerServices = headerServices;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserAddRequestDto user)
        {
            try
            {
                string? tokenHeader = _headerServices.GetAuthorizationHeader(HttpContext)!;
                return Ok(await _registerServices.CreateUserService(user, tokenHeader));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> ExtendVerification(ReinviteUserDto reinviteUserDto)
        {
            try
            {
                string? tokenHeader = _headerServices.GetAuthorizationHeader(HttpContext)!;
                return Ok(await _registerServices.ExtendVerificationValidityService(reinviteUserDto.EmailAddress, tokenHeader));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}