using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Org.BouncyCastle.Asn1.Misc;
using SchoolUser.Application.DTOs;
using SchoolUser.Controllers;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Domain.Models;

namespace SchoolUser.Tests.Controllers
{
    public class UserControllerTest
    {
        private readonly Mock<IUserServices> _userServices;
        private readonly Mock<ITokenServices> _tokenServices;
        private readonly Mock<IHeaderServices> _headerServices;
        private readonly UserController _controller;
        private Guid userId = Guid.NewGuid();
        private readonly UserResponseDto userResponseDto;
        private readonly UserUpdateRequestDto userUpdateRequestDto;
        private readonly UserVerifyAccountDto userVerifyAccountDto;
        private readonly UserChangePasswordDto userChangePasswordDto;
        private readonly UserResetPasswordDto userResetPasswordDto;
        private readonly UserRefreshJwtTokenDto userRefreshJwtTokenDto;
        private Guid refreshTokenIdRequest = Guid.NewGuid();
        private Guid refreshTokenIdResponse = Guid.NewGuid();

        public UserControllerTest()
        {
            _userServices = new Mock<IUserServices>();
            _tokenServices = new Mock<ITokenServices>();
            _headerServices = new Mock<IHeaderServices>();
            _controller = new UserController(_userServices.Object, _tokenServices.Object, _headerServices.Object);

            userResponseDto = new UserResponseDto
            {
                Id = userId,
                SerialTag = "000001",
                FullName = "Nickolas Student",
                EmailAddress = "nickolasstudent@example.com",
                MobileNumber = "0123456789",
                DateOfBirth = "01-01-2000",
                Gender = "Male",
                Age = 25,
                Roles = new List<string> { "student" },
                Student = null, // Student property remains null
                Teacher = null  // Teacher property remains null
            };


            userUpdateRequestDto = new UserUpdateRequestDto
            {
                UpdateForRole = "Student",
                Id = userId,
                FullName = "Nickolas Student",
                EmailAddress = "nickolasstudent@example.com",
                MobileNumber = "0123456789",
                DateOfBirth = new DateTime(2000, 1, 1),
                Gender = "Male",
                IsActive = true,

                // Teacher 
                ServiceStatus = "permanent",
                IsAvailable = true,

                // Student 
                EntranceYear = 2024,
                EstimatedExitYear = 2030,
                RealExitYear = null,
                ExitReason = null,

                // General properties
                ClassCategoryId = Guid.NewGuid(),
                ClassSubjectIds = new List<Guid>

                {
                    Guid.NewGuid(),
                    Guid.NewGuid()
                }
            };

            userVerifyAccountDto = new UserVerifyAccountDto
            {
                EmailAddress = "nickolas@example.com",
                MobileNumber = "1234567890",
                VerificationNumber = "123456"
            };

            userChangePasswordDto = new UserChangePasswordDto
            {
                EmailAddress = "nickolas@example.com",
                OldPassword = "123456@qweRTY",
                NewPassword = "qweRTY@123456",
                ConfirmNewPassword = "qweRTY@123456"
            };

            userResetPasswordDto = new UserResetPasswordDto
            {
                EmailAddress = "nickolas@example.com"
            };

            userRefreshJwtTokenDto = new UserRefreshJwtTokenDto
            {
                EmailAddress = "nickolas@example.com",
                RefreshToken = refreshTokenIdRequest.ToString()
            };
        }

        [Theory]
        [MemberData(nameof(GetUserTestData))]
        public async Task GetAllUsers_ReturnOkResult_WithUserPaginatedResponseDtoList(UsersListRequestDto requestDto, UsersListResponseDto responseDto)
        {
            _userServices.Setup(s => s.GetAllUsersService(requestDto)).ReturnsAsync(responseDto);

            var result = await _controller.GetAllUsers(requestDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<UsersListResponseDto>(okResult.Value);
            Assert.Equal(responseDto, returnValue);
            Assert.Equal(responseDto.PaginationList!.Count, returnValue.PaginationList!.Count);
        }

        [Fact]
        public async Task GetUser_ReturnOkResult_WithUserResponseDto()
        {
            _userServices.Setup(s => s.GetUserByIdService(userId)).ReturnsAsync(userResponseDto);

            var result = await _controller.GetUser(userId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<UserResponseDto>(okResult.Value);
            Assert.Equal(userResponseDto, returnValue);
            Assert.Equal(userResponseDto.SerialTag, returnValue.SerialTag);
        }

        [Fact]
        public async Task UpdateUser_ReturnOkResult_WithTrueValue()
        {
            var authHeader = "Bearer token123";

            _headerServices.Setup(x => x.GetAuthorizationHeader(It.IsAny<HttpContext>()))
                .Returns(authHeader);

            _userServices.Setup(s => s.UpdateUserService(userId, userUpdateRequestDto, authHeader)).ReturnsAsync(userResponseDto);

            var result = await _controller.UpdateUser(userId, userUpdateRequestDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<UserResponseDto>(okResult.Value);
            Assert.Equal(returnValue, userResponseDto);
        }

        [Fact]
        public async Task DeleteUser_ReturnOkResult_WithTrueValue()
        {
            _userServices.Setup(s => s.DeleteUserService(userId)).ReturnsAsync(true);

            var result = await _controller.DeleteUser(userId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task VerifyUser_ReturnOkResult_WithTrueValue()
        {
            _userServices.Setup(s => s.VerifyAccountService(userVerifyAccountDto)).ReturnsAsync(userResponseDto);

            var result = await _controller.VerifyAccount(userVerifyAccountDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<UserResponseDto>(okResult.Value);
            Assert.Equal(returnValue, userResponseDto);
        }

        [Fact]
        public async Task ChangePassword_ReturnOkResult_WithTrueValue()
        {
            _userServices.Setup(s => s.ChangePasswordService(userChangePasswordDto)).ReturnsAsync(userResponseDto);

            var result = await _controller.ChangePassword(userChangePasswordDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<UserResponseDto>(okResult.Value);
            Assert.Equal(returnValue, userResponseDto);
        }

        [Fact]
        public async Task ResetPassword_ReturnOkResult_WithTrueValue()
        {
            _userServices.Setup(s => s.ResetPasswordService(userResetPasswordDto)).ReturnsAsync(true);

            var result = await _controller.ResetPassword(userResetPasswordDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task RefreshJwtToken_ReturnOkResult_WithTrueValue()
        {
            _tokenServices.Setup(s => s.RefreshJwtTokenService(userId, userRefreshJwtTokenDto)).ReturnsAsync(refreshTokenIdResponse.ToString());

            var result = await _controller.RefreshJwtToken(userId, userRefreshJwtTokenDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<string>(okResult.Value);
            Assert.Equal(refreshTokenIdResponse.ToString(), returnValue);
        }

        public static IEnumerable<object[]> GetUserTestData()
        {
            var userId_Student = Guid.NewGuid();
            var userId_Teacher = Guid.NewGuid();

            return new List<Object[]>
            {
                new object[]
                {
                    new UsersListRequestDto
                    {
                        PageNumber = 1,
                        PageSize = 10,
                        RoleTitle = "student"
                    },
                    new UsersListResponseDto
                    {
                        TotalUsers = 1,
                        ReturnedUsers = 1,
                        PaginationList = new List<UserResponseDto>()
                        {
                            new UserResponseDto
                            {
                                Id = userId_Student,
                                SerialTag = "000001",
                                FullName = "Nickolas Student",
                                EmailAddress = "nickolasstudent@example.com",
                                MobileNumber = "0123456789",
                                DateOfBirth = "01-01-2000",
                                Gender = "Male",
                                Age = 25,
                                Roles = new List<string> { "student" },
                                Student = null,
                                Teacher = null
                            }
                        }
                    }
                },
                new object[]
                {
                    new UsersListRequestDto
                    {
                        PageNumber = 1,
                        PageSize = 10,
                        RoleTitle = "teacher"
                    },
                    new UsersListResponseDto
                    {
                        TotalUsers = 1,
                        ReturnedUsers = 1,
                        PaginationList = new List<UserResponseDto>()
                        {
                            new UserResponseDto
                            {
                                Id = userId_Teacher,
                                SerialTag = "000002",
                                FullName = "Nickolas Teacher",
                                EmailAddress = "nickolasteacher@example.com",
                                MobileNumber = "0123456789",
                                DateOfBirth = "01-01-1990",
                                Gender = "Male",
                                Age = 35,
                                Roles = new List<string> { "teacher" },
                                Student = null,
                                Teacher = null
                            }
                        }
                    }
                }
            };
        }

    }
}