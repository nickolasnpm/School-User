using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolUser.Application.DTOs;
using SchoolUser.Controllers;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Domain.Models;

namespace SchoolUser.Tests.Controllers
{
    public class SubjectControllerTest
    {
        private readonly Mock<ISubjectServices> _services;
        private readonly SubjectController _controller;
        private readonly SubjectDto subjectDto;
        private readonly Subject subject;
        private readonly List<Subject> subjectList;
        private Guid subjectId = Guid.NewGuid();
        private Guid teacherid = Guid.NewGuid();

        public SubjectControllerTest()
        {
            _services = new Mock<ISubjectServices>();
            _controller = new SubjectController(_services.Object);

            subjectDto = new SubjectDto
            {
                Name = "Mathematics",
                Code = "MATH",
                TeacherId = teacherid
            };

            subject = new Subject
            {
                Id = subjectId,
                Name = "Mathematics",
                Code = "MATH",
                TeacherId = teacherid,
                ClassSubjects = null,
                ClassCategories = null
            };

            subjectList = new List<Subject>()
            {
                subject
            };
        }

        [Fact]
        public async Task GetAllSubjects_ReturnsOkResult_WithListOfSubjects()
        {
            // Arrange
            _services.Setup(s => s.GetAllService()).ReturnsAsync(subjectList.AsEnumerable());

            // Act
            var result = await _controller.GetAllSubjects();

            // Assert 
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Subject>>(okResult.Value);
            Assert.Equal(subjectList.Count, returnValue.Count);
            Assert.Equal(subjectList, returnValue);
        }

        [Fact]
        public async Task GetSubjectById_ReturnsOkResult_WithSubject()
        {
            // Arrange
            _services.Setup(s => s.GetByIdService(subjectId)).ReturnsAsync(subject);

            // Act
            var result = await _controller.GetSubjectById(subjectId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Subject>(okResult.Value);
            Assert.Equal(subjectId, returnValue.Id);
        }

        [Fact]
        public async Task CreateSubject_ReturnsOkResult_WithCreatedModule()
        {
            // Arrange
            _services.Setup(s => s.CreateService(subjectDto)).ReturnsAsync(true);

            // Act
            var result = await _controller.CreateSubject(subjectDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task UpdateSubject_ReturnsOkResult_WithUpdatedModule()
        {
            // Arrange
            _services.Setup(s => s.UpdateService(subjectId, subjectDto)).ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateSubject(subjectId, subjectDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task DeleteSubject_ReturnsOkResult_WithDeletedStatus()
        {
            // Arrange
            _services.Setup(s => s.DeleteService(subjectId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteSubject(subjectId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }
    }
}