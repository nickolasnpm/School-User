using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/SchoolUser/[Controller]")]
    public class ClassStreamController : ControllerBase
    {
        private readonly IClassStreamServices _ClassStreamServices;

        public ClassStreamController(IClassStreamServices ClassStreamServices)
        {
            _ClassStreamServices = ClassStreamServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClassStreams([FromQuery] bool? isActive)
        {
            try
            {
                return Ok(await _ClassStreamServices.GetAllService(isActive));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetClassStreamById(Guid Id)
        {
            try
            {
                return Ok(await _ClassStreamServices.GetByIdService(Id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateClassStream(ClassStreamDto dto)
        {
            try
            {
                return Ok(await _ClassStreamServices.CreateService(dto));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateClassStream(Guid Id, ClassStreamDto dto)
        {
            try
            {
                return Ok(await _ClassStreamServices.UpdateService(Id, dto));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteClassStream(Guid Id)
        {
            try
            {
                return Ok(await _ClassStreamServices.DeleteService(Id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}