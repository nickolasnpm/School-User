using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/SchoolUser/[Controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;
        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        [HttpPut("BulkUpdateStudents")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> UpdateStudentsInBulk([FromBody] StudentsBulkUpdateDto updateStudentsDto)
        {
            try
            {
                return Ok(await _studentServices.UpdateStudentInBulkService(updateStudentsDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}