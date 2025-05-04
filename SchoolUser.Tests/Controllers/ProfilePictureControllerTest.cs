using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolUser.Application.DTOs;
using SchoolUser.Controllers;
using SchoolUser.Domain.Interfaces.Services;

namespace SchoolUser.Tests.Controllers
{
    public class ProfilePictureControllerTest
    {
        private readonly Mock<IFileServices> _fileServices;
        private readonly Mock<IHeaderServices> _headerServices;
        private readonly ProfilePictureController _controller;
        private readonly BlobDto blobDto;
        private readonly BlobResponseDto blobResponseDto;
        private readonly IFormFile file = new FormFile(new MemoryStream(), 0, 100, "test", "https://test.jpeg");
        private readonly string authHeader = "Bearer token123";

        public ProfilePictureControllerTest()
        {
            _fileServices = new Mock<IFileServices>();
            _headerServices = new Mock<IHeaderServices>();
            _controller = new ProfilePictureController(_fileServices.Object, _headerServices.Object);

            var dummyContent = new MemoryStream(System.Text.Encoding.UTF8.GetBytes("This is a test content for the blob."));

            blobDto = new BlobDto
            {
                Name = "test",
                ContentUri = "https://test.jpeg",
                ContentType = "image/jpeg",
                Content = dummyContent
            };

            blobResponseDto = new BlobResponseDto
            {
                Status = "Success",
                Error = false,
                blobDto = new BlobDto
                {
                    Name = "test",
                    ContentUri = "https://test.jpeg",
                    ContentType = "image/jpeg",
                    Content = dummyContent
                }
            };
        }

        [Fact]
        public async Task UploadProfilePicture_ReturnOkResult_WithValidFile()
        {
            // Arrange
            _headerServices.Setup(s => s.GetAuthorizationHeader(It.IsAny<HttpContext>())).Returns(authHeader);
            _fileServices.Setup(s => s.UploadAsync(file, authHeader)).ReturnsAsync(blobResponseDto);

            // Act
            var result = await _controller.UploadProfilePicture(file);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<BlobResponseDto>(okResult.Value);
            Assert.Equal(returnValue, blobResponseDto);
            Assert.Equal(returnValue.blobDto.Name, blobDto.Name);
        }

        [Fact]
        public async Task DownloadProfilePicture_ReturnOkResult_WithValidFile()
        {
            _fileServices.Setup(s => s.DownloadAsync("test")).ReturnsAsync(blobDto);

            var result = await _controller.DownloadProfilePicture("test");

            var fileStreamResult = Assert.IsType<FileStreamResult>(result);
            Assert.Equal(blobDto.Content, fileStreamResult.FileStream);
            Assert.Equal(blobDto.ContentType, fileStreamResult.ContentType);
            Assert.Equal(blobDto.Name, fileStreamResult.FileDownloadName);
        }
    }
}