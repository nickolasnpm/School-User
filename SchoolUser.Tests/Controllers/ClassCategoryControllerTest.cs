using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolUser.Application.DTOs;
using SchoolUser.Controllers;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Domain.Models;

namespace SchoolUser.Tests.Controllers
{
    public class ClassCategoryControllerTest
    {
        private readonly Mock<IClassCategoryServices> _mockClassCategoryServices;
        private readonly ClassCategoryController _controller;
        private readonly ClassCategory classCategory;
        private readonly List<ClassCategory> classCategoriesList;
        private readonly ClassCategoryDto classCategoryDto;
        private Guid classCategoryId = Guid.NewGuid();
        private Guid batchId = Guid.NewGuid();
        private Guid classStreamId = Guid.NewGuid();
        private Guid classRankId = Guid.NewGuid();

        public ClassCategoryControllerTest()
        {
            _mockClassCategoryServices = new Mock<IClassCategoryServices>();
            _controller = new ClassCategoryController(_mockClassCategoryServices.Object);

            classCategory = new ClassCategory
            {
                Id = classCategoryId,
                Code = "1-S-A",
                AcademicYear = 2024,
                BatchId = batchId,
                ClassStreamId = classStreamId,
                ClassRankId = classRankId,
                ClassSubjects = null,
                Subjects = null,
                Students = null,
                Teachers = null
            };

            classCategoriesList = new List<ClassCategory>
            {
                classCategory
            };

            classCategoryDto = new ClassCategoryDto
            {
                AcademicYear = 2024,
                BatchId = batchId,
                ClassStreamId = classStreamId,
                ClassRankId = classRankId,
                SubjectIds = null
            };
        }

        [Fact]
        public async Task GetClassCategories_ReturnOkResult_WithClassCategoryList()
        {
            _mockClassCategoryServices.Setup(s => s.GetAllService()).ReturnsAsync(classCategoriesList.AsEnumerable());

            var result = await _controller.GetAllClassCategories();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ClassCategory>>(okResult.Value);
            Assert.Equal(classCategoriesList, returnValue);
            Assert.Equal(classCategoriesList.Count, returnValue.Count);
        }

        [Fact]
        public async Task GetClassCategoryById_ReturnOkResult_WithClassCategory()
        {
            _mockClassCategoryServices.Setup(s => s.GetByIdService(classCategoryId)).ReturnsAsync(classCategory);

            var result = await _controller.GetClassCategoryById(classCategoryId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ClassCategory>(okResult.Value);
            Assert.Equal(classCategory, returnValue);
            Assert.Equal(classCategory.Id, returnValue.Id);
        }

        [Fact]
        public async Task CreateClassCategory_ReturnOkResult_WithTrueValue()
        {
            _mockClassCategoryServices.Setup(s => s.CreateService(classCategoryDto)).ReturnsAsync(true);

            var result = await _controller.CreateClassCategory(classCategoryDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task UpdateClassCategory_ReturnOkResult_WithTrueValue()
        {
            _mockClassCategoryServices.Setup(s => s.UpdateOfferedSubjectService(classCategoryId, classCategoryDto)).ReturnsAsync(true);

            var result = await _controller.UpdateClassCategory(classCategoryId, classCategoryDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task DeleteClassCategory_ReturnOkResult_WithTrueValue()
        {
            _mockClassCategoryServices.Setup(s => s.DeleteService(classCategoryId)).ReturnsAsync(true);

            var result = await _controller.DeleteClassCategory(classCategoryId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }
    }
}