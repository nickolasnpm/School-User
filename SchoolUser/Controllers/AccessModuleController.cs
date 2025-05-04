using Microsoft.AspNetCore.Mvc;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;

// AccessModule can create or update RoleAccessModule, Role cannot create or update RoleAccessModule

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/SchoolUser/[Controller]")]
    public class AccessModuleController : ControllerBase
    {
        private readonly IAccessModuleServices _accessModuleServices;

        public AccessModuleController(IAccessModuleServices accessModuleServices)
        {
            _accessModuleServices = accessModuleServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccessModules()
        {
            try
            {
                return Ok(await _accessModuleServices.GetAllService());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAccessModuleById(Guid Id)
        {
            try
            {
                return Ok(await _accessModuleServices.GetByIdService(Id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccessModule(AccessModuleDto dto)
        {
            try
            {
                return Ok(await _accessModuleServices.CreateService(dto));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateAccessModule(Guid Id, AccessModuleDto dto)
        {
            try
            {
                return Ok(await _accessModuleServices.UpdateService(Id, dto));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAccessModule(Guid Id)
        {
            try
            {
                return Ok(await _accessModuleServices.DeleteService(Id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}