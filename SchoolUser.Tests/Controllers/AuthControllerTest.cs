using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolUser.Application.DTOs;
using SchoolUser.Controllers;
using SchoolUser.Domain.Interfaces.Services;

namespace SchoolUser.Tests.Controllers
{
    public class AuthControllerTest
    {
        private readonly Mock<IAuthServices> _mockAuthServices;
        private readonly AuthController _controller;
        private readonly LoginRequestDto _loginRequestDto;
        private readonly LoginResponseDto _loginResponseDto;
        private Guid authId = Guid.NewGuid();
        private Guid accesstoken = Guid.NewGuid();
        private Guid refreshToken = Guid.NewGuid();

        public AuthControllerTest()
        {
            _mockAuthServices = new Mock<IAuthServices>();
            _controller = new AuthController(_mockAuthServices.Object);

            _loginRequestDto = new LoginRequestDto
            {
                EmailAddress = "nickolas@example.com",
                Password = "1234qwerASDF_"
            };

            _loginResponseDto = new LoginResponseDto
            {
                Id = authId,
                AccessToken = accesstoken.ToString(),
                RefreshToken = refreshToken.ToString()
            };
        }

        [Fact]
        public async Task Login_ReturnOkResult_WithLoginResponseDto()
        {
            // Arrange
            _mockAuthServices.Setup(s => s.LoginService(_loginRequestDto)).ReturnsAsync(_loginResponseDto);

            // Act
            var result = await _controller.Login(_loginRequestDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<LoginResponseDto>(okResult.Value);
            Assert.Equal(_loginResponseDto, returnValue);
        }

        [Fact]
        public async Task Login_ReturnBadRequest_withExceptionMessage()
        {
            // Arrange
            _mockAuthServices.Setup(s => s.LoginService(_loginRequestDto)).ThrowsAsync(new Exception("Error"));

            // Act
            var result = await _controller.Login(_loginRequestDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Error", badRequestResult.Value);
        }

        [Fact]
        public async Task Logout_ReturnOkResult_WithTruealue()
        {
            // Arrange
            _mockAuthServices.Setup(s => s.LogoutService(authId)).ReturnsAsync(true);

            // Act
            var result = await _controller.Logout(authId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task Logout_ReturnBadRequest_WithExceptionMessage()
        {
            // Arrange
            _mockAuthServices.Setup(s => s.LogoutService(authId)).ThrowsAsync(new Exception("Error"));

            // Act
            var result = await _controller.Logout(authId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Error", badRequestResult.Value);
        }
    }
}