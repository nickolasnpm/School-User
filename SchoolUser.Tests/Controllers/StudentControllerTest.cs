using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolUser.Application.DTOs;
using SchoolUser.Controllers;
using SchoolUser.Domain.Interfaces.Services;

namespace SchoolUser.Tests.Controllers
{
    public class StudentControllerTest
    {
        private readonly Mock<IStudentServices> _services;
        private readonly StudentController _controller;
        private readonly StudentsBulkUpdateDto updateDto;

        public StudentControllerTest()
        {
            _services = new Mock<IStudentServices>();
            _controller = new StudentController(_services.Object);

            updateDto = new StudentsBulkUpdateDto
            {
                StudentIds = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                EntranceYear = 2015,
                EstimatedExitYear = 2020,
                RealExitYear = 2020,
                ExitReason = "completed school",
                IsActive = false,
                ClassCategoryId = Guid.NewGuid()
            };
        }

        [Fact]
        public async Task UpdateStudentsInBulk_ReturnOkResult_WithTrueValue()
        {
            _services.Setup(s => s.UpdateStudentInBulkService(updateDto)).ReturnsAsync(true);

            var result = await _controller.UpdateStudentsInBulk(updateDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }
    }
}