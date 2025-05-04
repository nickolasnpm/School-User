using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolUser.Application.DTOs;
using SchoolUser.Controllers;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Domain.Models;

namespace SchoolUser.Tests.Controllers
{
    public class AccessModuleControllerTests
    {
        private readonly Mock<IAccessModuleServices> _services;
        private readonly AccessModuleController _controller;
        private readonly AccessModuleDto accessModuleDto;
        private readonly AccessModule accessModule;
        private readonly List<AccessModule> accessModuleList;
        private readonly List<RoleAccessModule> roleAccessModuleList;
        private readonly List<Role> roleList;

        private Guid accessModuleId = Guid.NewGuid();
        private Guid roleaccessModuleId = Guid.NewGuid();
        private Guid roleAccessModuleId = Guid.NewGuid();

        public AccessModuleControllerTests()
        {
            _services = new Mock<IAccessModuleServices>();
            _controller = new AccessModuleController(_services.Object);

            roleList = new List<Role>
            {
                new Role {
                    Id = roleaccessModuleId,
                    Title = "teacher",
                    UserRoles = null,
                    RoleAccessModules = null,
                    AccessModules = null
                }
            };

            roleAccessModuleList = new List<RoleAccessModule>
            {
                new RoleAccessModule {
                    Id = roleAccessModuleId,
                    RoleId = roleaccessModuleId,
                    AccessModuleId = accessModuleId
                }
            };

            accessModule = new AccessModule
            {
                Id = accessModuleId,
                Name = "Module1",
                RoleAccessModules = roleAccessModuleList,
                Roles = roleList
            };

            accessModuleList = new List<AccessModule>
            {
                accessModule
            };

            accessModuleDto = new AccessModuleDto
            {
                Name = "Module1",
                RoleIds = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() }
            };

        }

        [Fact]
        public async Task GetAllAccessModules_ReturnsOkResult_WithListOfAccessModules()
        {
            // Arrange
            _services.Setup(s => s.GetAllService()).ReturnsAsync(accessModuleList.AsEnumerable());

            // Act
            var result = await _controller.GetAllAccessModules();

            // Assert 
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<AccessModule>>(okResult.Value);
            Assert.Equal(accessModuleList.Count, returnValue.Count);
            Assert.Equal(accessModuleList, returnValue);
        }

        [Fact]
        public async Task GetAccessModuleById_ReturnsOkResult_WithAccessModule()
        {
            // Arrange
            _services.Setup(s => s.GetByIdService(accessModuleId)).ReturnsAsync(accessModule);

            // Act
            var result = await _controller.GetAccessModuleById(accessModuleId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<AccessModule>(okResult.Value);
            Assert.Equal(accessModuleId, returnValue.Id);
        }

        [Fact]
        public async Task CreateAccessModule_ReturnsOkResult_WithCreatedModule()
        {
            // Arrange
            _services.Setup(s => s.CreateService(accessModuleDto)).ReturnsAsync(true);

            // Act
            var result = await _controller.CreateAccessModule(accessModuleDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task UpdateAccessModule_ReturnsOkResult_WithUpdatedModule()
        {
            // Arrange
            _services.Setup(s => s.UpdateService(accessModuleId, accessModuleDto)).ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateAccessModule(accessModuleId, accessModuleDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task DeleteAccessModule_ReturnsOkResult_WithDeletedStatus()
        {
            // Arrange
            _services.Setup(s => s.DeleteService(accessModuleId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteAccessModule(accessModuleId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }
    }
}
