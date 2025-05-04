using Microsoft.AspNetCore.Mvc;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/SchoolUser/[Controller]")]
    public class ClassRankController : ControllerBase
    {
        private readonly IClassRankServices _classRankServices;

        public ClassRankController(IClassRankServices classRankServices)
        {
            _classRankServices = classRankServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClassRanks([FromQuery] bool? isActive)
        {
            try
            {
                return Ok(await _classRankServices.GetAllService(isActive));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetClassRankById(Guid Id)
        {
            try
            {
                return Ok(await _classRankServices.GetByIdService(Id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateClassRank(ClassRankDto dto)
        {
            try
            {
                return Ok(await _classRankServices.CreateService(dto));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateClassRank(Guid Id, ClassRankDto dto)
        {
            try
            {
                return Ok(await _classRankServices.UpdateService(Id, dto));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteClassRank(Guid Id)
        {
            try
            {
                return Ok(await _classRankServices.DeleteService(Id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}