using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// Class category can create or update class subject, but subject cannot create or update class subject

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/SchoolUser/[Controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectServices _subjectServices;

        public SubjectController(ISubjectServices subjectServices)
        {
            _subjectServices = subjectServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            try
            {
                return Ok(await _subjectServices.GetAllService());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSubjectById(Guid Id)
        {
            try
            {
                return Ok(await _subjectServices.GetByIdService(Id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject(SubjectDto dto)
        {
            try
            {
                return Ok(await _subjectServices.CreateService(dto));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateSubject(Guid Id, SubjectDto dto)
        {
            try
            {
                return Ok(await _subjectServices.UpdateService(Id, dto));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteSubject(Guid Id)
        {
            try
            {
                return Ok(await _subjectServices.DeleteService(Id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}