using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolUser.Application.DTOs;
using SchoolUser.Controllers;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Domain.Models;

namespace SchoolUser.Tests.Controllers
{
    public class ClassStreamControllerTest
    {

        private readonly Mock<IClassStreamServices> _services;
        private readonly ClassStreamController _controller;
        private readonly ClassStreamDto classStreamDto;
        private readonly ClassStream classStream1;
        private readonly ClassStream classStream2;
        private readonly List<ClassStream> classStreamsList1;
        private readonly List<ClassStream> classStreamsList2;
        private Guid classStreamId1 = Guid.NewGuid();
        private Guid classStreamId2 = Guid.NewGuid();

        public ClassStreamControllerTest()
        {
            _services = new Mock<IClassStreamServices>();
            _controller = new ClassStreamController(_services.Object);

            classStreamDto = new ClassStreamDto
            {
                Name = "Art",
                Code = "ART",
                IsActive = true
            };

            classStream1 = new ClassStream
            {
                Id = classStreamId1,
                Name = "Art",
                Code = "ART",
                IsActive = true,
                ClassCategories = null,
                Batches = null,
                ClassRanks = null
            };

            classStream2 = new ClassStream
            {
                Id = classStreamId2,
                Name = "Science",
                Code = "SCN",
                IsActive = false,
                ClassCategories = null,
                Batches = null,
                ClassRanks = null
            };

            classStreamsList1 = new List<ClassStream>()
            {
                classStream1
            };

            classStreamsList2 = new List<ClassStream>()
            {
                classStream1, classStream2
            };
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [InlineData(null)]
        public async Task GetAllClassStreames_ReturnOkResult_WithListOfClassStreames(bool? isActive)
        {
            var objList = new List<ClassStream>();

            if (isActive.HasValue && isActive.Value)
            {
                objList = classStreamsList1;
            }
            else
            {
                objList = classStreamsList2;
            }

            _services.Setup(s => s.GetAllService(isActive)).ReturnsAsync(objList.AsEnumerable());

            var result = await _controller.GetAllClassStreams(isActive);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ClassStream>>(okResult.Value);
            Assert.Equal(objList.Count, returnValue.Count);
            Assert.Equal(objList, returnValue);

            if (isActive.HasValue && isActive.Value)
            {
                Assert.All(returnValue, obj => Assert.True(obj.IsActive));
            }
            else
            {
                Assert.Contains(returnValue, obj => obj.IsActive);
                Assert.Contains(returnValue, obj => !obj.IsActive);
            }
        }

        [Fact]
        public async Task GetClassStreamById_ReturnOkResult_WithClassStreamObject()
        {
            _services.Setup(s => s.GetByIdService(classStreamId1)).ReturnsAsync(classStream1);

            var result = await _controller.GetClassStreamById(classStreamId1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ClassStream>(okResult.Value);
            Assert.Equal(classStreamId1, returnValue.Id);
            Assert.Equal(classStream1, returnValue);
        }

        [Fact]
        public async Task CreateClassStream_ReturnOkResult_WithBoolValueTrue()
        {
            _services.Setup(s => s.CreateService(classStreamDto)).ReturnsAsync(true);

            var result = await _controller.CreateClassStream(classStreamDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task UpdateClassStream_ReturnOkResult_WithBoolValueTrue()
        {
            _services.Setup(s => s.UpdateService(classStreamId1, classStreamDto)).ReturnsAsync(true);

            var result = await _controller.UpdateClassStream(classStreamId1, classStreamDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task DeleteClassStream_ReturnOkResult_WithBoolValueTrue()
        {
            _services.Setup(s => s.DeleteService(classStreamId1)).ReturnsAsync(true);

            var result = await _controller.DeleteClassStream(classStreamId1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }
    }
}