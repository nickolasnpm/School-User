using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolUser.Application.DTOs;
using SchoolUser.Controllers;
using SchoolUser.Domain.Interfaces.Services;

namespace SchoolUser.Tests.Controllers
{
    public class PublishingControllerTest
    {
        private readonly Mock<IPublishingServices> _services;
        private readonly PublishingController _controller;
        private readonly StudentToBePublishedDto dto;
        private Guid studentId = Guid.NewGuid();
        private Guid classId = Guid.NewGuid();

        public PublishingControllerTest()
        {
            _services = new Mock<IPublishingServices>();
            _controller = new PublishingController(_services.Object);

            dto = new StudentToBePublishedDto
            {
                StudentName = "Nickolas",
                StudentId = studentId.ToString(),
                ClassId = classId.ToString(),
                ClassName = "1-S-A",
                EmailAddress = "nickolas@example.com"
            };
        }

        [Fact]
        public async Task PublishDailyAttendanceCheckList_ReturnOkResult_WithTrueValue()
        {
            _services.Setup(s => s.PublishDailyAttendanceCheckListService()).ReturnsAsync(true);

            var result = await _controller.PublishDailyAttendanceCheckList();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task PublishMonthlyAttendanceReport_ReturnOkResult_WithTrueValue()
        {
            _services.Setup(s => s.PublishMonthlyAttendanceReportService()).ReturnsAsync(true);

            var result = await _controller.PublishMonthlyAttendanceReport();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task PublishAnnualAttendanceRecords_ReturnOkResult_WithTrueValue()
        {
            _services.Setup(s => s.PublishAnnualAttendanceRecordsService(null)).ReturnsAsync(true);

            var result = await _controller.PublishAnnualAttendanceRecords();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }
    }
}