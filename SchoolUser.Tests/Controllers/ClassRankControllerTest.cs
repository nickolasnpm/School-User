using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolUser.Application.DTOs;
using SchoolUser.Controllers;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Domain.Models;

namespace SchoolUser.Tests.Controllers
{
    public class ClassRankControllerTest
    {
        private readonly Mock<IClassRankServices> _services;
        private readonly ClassRankController _controller;
        private readonly ClassRankDto classRankDto;
        private readonly ClassRank classRank1;
        private readonly ClassRank classRank2;
        private readonly List<ClassRank> classRanksList1;
        private readonly List<ClassRank> classRanksList2;
        private Guid classRankId1 = Guid.NewGuid();
        private Guid classRankId2 = Guid.NewGuid();

        public ClassRankControllerTest()
        {
            _services = new Mock<IClassRankServices>();
            _controller = new ClassRankController(_services.Object);

            classRankDto = new ClassRankDto
            {
                Name = "First",
                Code = "A",
                IsActive = true
            };

            classRank1 = new ClassRank
            {
                Id = classRankId1,
                Name = "First",
                Code = "A",
                IsActive = true,
                ClassCategories = null,
                Batches = null,
                ClassStreams = null
            };

            classRank2 = new ClassRank
            {
                Id = classRankId1,
                Name = "Second",
                Code = "B",
                IsActive = false,
                ClassCategories = null,
                Batches = null,
                ClassStreams = null
            };

            classRanksList1 = new List<ClassRank>
            {
                classRank1, classRank2
            };

            classRanksList2 = new List<ClassRank>
            {
                classRank1
            };
        }


        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [InlineData(null)]
        public async Task GetAllBatches_ReturnOkResult_WithListOfBatches(bool? isActive)
        {
            var objList = new List<ClassRank>();

            if (isActive.HasValue && isActive.Value)
            {
                objList = classRanksList2;
            }
            else
            {
                objList = classRanksList1;
            }

            _services.Setup(s => s.GetAllService(isActive)).ReturnsAsync(objList.AsEnumerable());

            var result = await _controller.GetAllClassRanks(isActive);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ClassRank>>(okResult.Value);
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
        public async Task GetClassRankById_ReturnOkResult_WithClassRankObject()
        {
            _services.Setup(s => s.GetByIdService(classRankId1)).ReturnsAsync(classRank1);

            var result = await _controller.GetClassRankById(classRankId1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ClassRank>(okResult.Value);
            Assert.Equal(classRankId1, returnValue.Id);
            Assert.Equal(classRank1, returnValue);
        }

        [Fact]
        public async Task CreateClassRank_ReturnOkResult_WithBoolValueTrue()
        {
            _services.Setup(s => s.CreateService(classRankDto)).ReturnsAsync(true);

            var result = await _controller.CreateClassRank(classRankDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }


        [Fact]
        public async Task UpdateClassrank_ReturnOkResult_WithBoolValueTrue()
        {
            _services.Setup(s => s.UpdateService(classRankId1, classRankDto)).ReturnsAsync(true);

            var result = await _controller.UpdateClassRank(classRankId1, classRankDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }


        [Fact]
        public async Task DeleteClassRank_ReturnOkResult_WithBoolValueTrue()
        {
            _services.Setup(s => s.DeleteService(classRankId1)).ReturnsAsync(true);

            var result = await _controller.DeleteClassRank(classRankId1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

    }
}