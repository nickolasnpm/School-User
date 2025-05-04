using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/SchoolUser/[Controller]")]
    public class ClassSubjectController : ControllerBase
    {
        private readonly IClassSubjectServices _classSubjectServices;

        public ClassSubjectController(IClassSubjectServices classSubjectServices)
        {
            _classSubjectServices = classSubjectServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClassSubjects()
        {
            try
            {
                return Ok(await _classSubjectServices.GetAllService());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetClassSubjectById(Guid Id)
        {
            try
            {
                return Ok(await _classSubjectServices.GetByIdService(Id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteClassSubject(Guid Id)
        {
            try
            {
                return Ok(await _classSubjectServices.DeleteService(Id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}