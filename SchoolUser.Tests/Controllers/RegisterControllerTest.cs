using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolUser.Application.DTOs;
using SchoolUser.Controllers;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Domain.Models;

namespace SchoolUser.Tests.Controllers
{
    public class RegisterControllerTest
    {
        private readonly Mock<IRegisterServices> _registerServices;
        private readonly Mock<IHeaderServices> _headerServices;
        private readonly RegisterController _controller;
        private readonly string _authHeader = "Bearer token123";

        public RegisterControllerTest()
        {
            _registerServices = new Mock<IRegisterServices>();
            _headerServices = new Mock<IHeaderServices>();
            _controller = new RegisterController(_registerServices.Object, _headerServices.Object);
        }

        [Theory]
        [MemberData(nameof(GetUserTestData))]
        public async Task RegisterUser_ShouldReturnOkResult(UserAddRequestDto requestDto, UserResponseDto expectedResponse)
        {
            _headerServices.Setup(s => s.GetAuthorizationHeader(It.IsAny<HttpContext>())).Returns(_authHeader);
            _registerServices.Setup(s => s.CreateUserService(requestDto, _authHeader)).ReturnsAsync(expectedResponse);

            var result = await _controller.Register(requestDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<UserResponseDto>(okResult.Value);
            Assert.Equal(expectedResponse, returnValue);
        }

        public static IEnumerable<object[]> GetUserTestData()
        {
            var classCategoryId = Guid.NewGuid();
            return new List<object[]>
            {
                new object[]
                {
                    new UserAddRequestDto
                    {
                        RegisterForRole = "teacher",
                        FullName = "John Doe",
                        EmailAddress = "johndoe@example.com",
                        MobileNumber = "1234567890",
                        DateOfBirth = new DateTime(1985, 1, 1),
                        Gender = "Male",
                        ServiceStatus = "Permanent",
                        IsAvailable = true,
                        ClassCategoryId = classCategoryId,
                        ClassSubjectIds = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() }
                    },
                    new UserResponseDto
                    {
                        Id = Guid.NewGuid(),
                        SerialTag = "000001",
                        FullName = "John Doe",
                        EmailAddress = "johndoe@example.com",
                        MobileNumber = "1234567890",
                        DateOfBirth = "01-01-1985",
                        Gender = "Male",
                        Age = 40,
                        Roles = new List<string> {"teacher" },
                    }
                },
                new object[]
                {
                    new UserAddRequestDto
                    {
                        RegisterForRole = "student",
                        FullName = "Doe John",
                        EmailAddress = "doejohn@example.com",
                        MobileNumber = "1234567890",
                        DateOfBirth = new DateTime(2000, 1, 1),
                        Gender = "Male",
                        EntranceYear = 2015,
                        EstimatedExitYear = 2020,
                        ClassCategoryId = classCategoryId,
                        ClassSubjectIds = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() }
                    },
                    new UserResponseDto
                    {
                        Id = Guid.NewGuid(),
                        SerialTag = "000002",
                        FullName = "Doe John",
                        EmailAddress = "doejohn@example.com",
                        MobileNumber = "1234567890",
                        DateOfBirth = "01-01-2000",
                        Gender = "Male",
                        Age = 25,
                        Roles = new List<string> { "student" },
                    }
                }
            };
        }
    }
}
