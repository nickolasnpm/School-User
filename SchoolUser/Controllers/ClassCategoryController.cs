using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// Class category can create or update class subject, but subject cannot create or update class subject

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/SchoolUser/[Controller]")]
    public class ClassCategoryController : ControllerBase
    {
        private readonly IClassCategoryServices _classCategoryServices;

        public ClassCategoryController(IClassCategoryServices classCategoryServices)
        {
            _classCategoryServices = classCategoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClassCategories()
        {
            try
            {
                return Ok(await _classCategoryServices.GetAllService());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetClassCategoryById(Guid Id)
        {
            try
            {
                return Ok(await _classCategoryServices.GetByIdService(Id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateClassCategory(ClassCategoryDto dto)
        {
            try
            {
                return Ok(await _classCategoryServices.CreateService(dto));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateClassCategory(Guid Id, ClassCategoryDto dto)
        {
            try
            {
                return Ok(await _classCategoryServices.UpdateOfferedSubjectService(Id, dto));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteClassCategory(Guid Id)
        {
            try
            {
                return Ok(await _classCategoryServices.DeleteService(Id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}