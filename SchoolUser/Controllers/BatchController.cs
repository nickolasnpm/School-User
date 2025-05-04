using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/SchoolUser/[Controller]")]
    public class BatchController : ControllerBase
    {
        private readonly IBatchServices _batchServices;

        public BatchController(IBatchServices batchServices)
        {
            _batchServices = batchServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBatches([FromQuery] bool? isActive)
        {
            try
            {
                return Ok(await _batchServices.GetAllService(isActive));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetBatchById(Guid Id)
        {
            try
            {
                return Ok(await _batchServices.GetByIdService(Id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBatch(BatchDto dto)
        {
            try
            {
                return Ok(await _batchServices.CreateService(dto));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateBatch(Guid Id, BatchDto dto)
        {
            try
            {
                return Ok(await _batchServices.UpdateService(Id, dto));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBatch(Guid Id)
        {
            try
            {
                return Ok(await _batchServices.DeleteService(Id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}