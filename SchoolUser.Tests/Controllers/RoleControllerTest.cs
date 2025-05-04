using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolUser.Application.DTOs;
using SchoolUser.Controllers;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Domain.Models;

namespace SchoolUser.Tests.Controllers
{
    public class RoleControllerTest
    {
        private readonly Mock<IRoleServices> _services;
        private readonly RoleController _controller;
        private readonly RoleDto roleDto;
        private readonly Role role;
        private readonly List<Role> rolesList;
        private Guid roleId = Guid.NewGuid();

        public RoleControllerTest()
        {
            _services = new Mock<IRoleServices>();
            _controller = new RoleController(_services.Object);

            roleDto = new RoleDto
            {
                Title = "student"
            };

            role = new Role
            {
                Id = roleId,
                Title = "student"
            };

            rolesList = new List<Role>()
            {
                role
            };
        }

        [Fact]
        public async Task GetAllRole_ReturnOkResult_WithReturnObject()
        {
            // Arrange
            _services.Setup(service => service.GetAllRolesService()).ReturnsAsync(rolesList);

            // Act
            var result = await _controller.GetAllRole();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Role>>(okResult.Value);
            Assert.Equal(rolesList, returnValue);
            Assert.Equal(rolesList.Count, returnValue.Count);
        }

        [Fact]
        public async Task GetRole_ReturnOkResult_WithReturnObject()
        {
            // Arrange
            _services.Setup(service => service.GetRoleService(roleId)).ReturnsAsync(role);

            // Act
            var result = await _controller.GetRole(roleId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Role>(okResult.Value);
            Assert.Equal(role, returnValue);
            Assert.Equal(role.Title, returnValue.Title);
        }

        [Fact]
        public async Task CreateRole_ReturnOkResult_WithReturnObject()
        {
            // Arrange
            _services.Setup(service => service.CreateRoleService(roleDto)).ReturnsAsync(true);

            // Act
            var result = await _controller.CreateRole(roleDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task UpdateRole_ReturnOkResult_WithReturnObject()
        {
            // Arrange
            _services.Setup(service => service.UpdateRoleService(roleId, roleDto)).ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateRole(roleId, roleDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task DeleteRole_ReturnOkResult_WithReturnObject()
        {
            // Arrange
            _services.Setup(service => service.DeleteRoleService(roleId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteRole(roleId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }
    }
}