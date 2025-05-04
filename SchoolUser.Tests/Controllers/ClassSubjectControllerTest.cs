using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolUser.Application.DTOs;
using SchoolUser.Controllers;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Domain.Models;

namespace SchoolUser.Tests.Controllers
{
    public class ClassSubjectControllerTest
    {
        private readonly Mock<IClassSubjectServices> _services;
        private readonly ClassSubjectController _controller;
        private readonly ClassSubjectDto classSubjectDto;
        private readonly ClassSubject classSubject;
        private readonly List<ClassSubject> classSubjectsList;
        private Guid classSubjectId = Guid.NewGuid();
        private Guid classCategoryId = Guid.NewGuid();
        private Guid subjectId = Guid.NewGuid();

        public ClassSubjectControllerTest()
        {
            _services = new Mock<IClassSubjectServices>();
            _controller = new ClassSubjectController(_services.Object);

            classSubjectDto = new ClassSubjectDto()
            {
                ClassCategoryId = classCategoryId,
                SubjectId = subjectId
            };

            classSubject = new ClassSubject()
            {
                Id = classSubjectId,
                Code = "1-S-A-BM",
                AcademicYear = 2024,
                ClassCategoryId = classCategoryId,
                SubjectId = subjectId,
                Teachers = null,
                Students = null
            };

            classSubjectsList = new List<ClassSubject>()
            {
                classSubject
            };
        }

        [Fact]
        public async Task GetAllClassSubjects_ReturnsOkResult_WithListOfClassSubjects()
        {
            // Arrange
            _services.Setup(s => s.GetAllService()).ReturnsAsync(classSubjectsList.AsEnumerable());

            // Act
            var result = await _controller.GetAllClassSubjects();

            // Assert 
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ClassSubject>>(okResult.Value);
            Assert.Equal(classSubjectsList.Count, returnValue.Count);
            Assert.Equal(classSubjectsList, returnValue);
        }

        [Fact]
        public async Task GetClassSubjectById_ReturnsOkResult_WithClassSubject()
        {
            // Arrange
            _services.Setup(s => s.GetByIdService(classSubjectId)).ReturnsAsync(classSubject);

            // Act
            var result = await _controller.GetClassSubjectById(classSubjectId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ClassSubject>(okResult.Value);
            Assert.Equal(classSubjectId, returnValue.Id);
            Assert.Equal(2024, returnValue.AcademicYear);
        }

        [Fact]
        public async Task DeleteAccessModule_ReturnsOkResult_WithDeletedStatus()
        {
            // Arrange
            _services.Setup(s => s.DeleteService(classSubjectId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteClassSubject(classSubjectId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }
    }
}