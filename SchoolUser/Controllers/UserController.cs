using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/SchoolUser/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly ITokenServices _tokenServices;
        private readonly IHeaderServices _headerServices;

        public UserController(IUserServices userServices, ITokenServices tokenServices, IHeaderServices headerServices)
        {
            _userServices = userServices;
            _tokenServices = tokenServices;
            _headerServices = headerServices;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> GetAllUsers([FromQuery] UsersListRequestDto? requestDto)
        {
            try
            {
                return Ok(await _userServices.GetAllUsersService(requestDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        [Authorize]
        public async Task<IActionResult> GetUser(Guid Id)
        {
            try
            {
                return Ok(await _userServices.GetUserByIdService(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(Guid Id, UserUpdateRequestDto userUpdateDto)
        {
            try
            {
                string? tokenHeader = _headerServices.GetAuthorizationHeader(HttpContext)!;
                return Ok(await _userServices.UpdateUserService(Id, userUpdateDto, tokenHeader));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(Guid Id)
        {
            try
            {
                return Ok(await _userServices.DeleteUserService(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("VerifyAccount")]
        [Authorize]
        public async Task<IActionResult> VerifyAccount(UserVerifyAccountDto verifyAccountDto)
        {
            try
            {
                return Ok(await _userServices.VerifyAccountService(verifyAccountDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ChangePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(UserChangePasswordDto changePasswordDto)
        {
            try
            {
                return Ok(await _userServices.ChangePasswordService(changePasswordDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ResetPassword")]
        public async Task<IActionResult> ResetPassword(UserResetPasswordDto resetPasswordDto)
        {
            try
            {
                return Ok(await _userServices.ResetPasswordService(resetPasswordDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("RefreshToken/{Id}")]
        [Authorize]
        public async Task<IActionResult> RefreshJwtToken(Guid Id, UserRefreshJwtTokenDto refreshJwtTokenDto)
        {
            try
            {
                return Ok(await _tokenServices.RefreshJwtTokenService(Id, refreshJwtTokenDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}