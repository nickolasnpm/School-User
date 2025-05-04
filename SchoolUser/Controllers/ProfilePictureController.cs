using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;

namespace SchoolUser.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/SchoolUser/[Controller]")]
    public class ProfilePictureController : ControllerBase
    {

        private readonly IFileServices _fileServices;
        private readonly IHeaderServices _headerServices;

        public ProfilePictureController(IFileServices fileServices, IHeaderServices headerServices)
        {
            _fileServices = fileServices;
            _headerServices = headerServices;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadProfilePicture(IFormFile formFile)
        {
            try
            {
                string? tokenHeader = _headerServices.GetAuthorizationHeader(HttpContext)!;
                return Ok(await _fileServices.UploadAsync(formFile, tokenHeader));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Download")]
        public async Task<IActionResult> DownloadProfilePicture([FromQuery] string fileName)
        {
            try
            {
                BlobDto? result = await _fileServices.DownloadAsync(fileName);

                if (result == null)
                {
                    return NotFound();
                }

                return File(result.Content!, result.ContentType!, result.Name);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}