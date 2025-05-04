using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolUser.Application.DTOs;
using SchoolUser.Controllers;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Domain.Models;

namespace SchoolUser.Tests.Controllers
{
    public class BatchControllerTest
    {

        private readonly Mock<IBatchServices> _mockBatchServices;
        private readonly BatchController _controller;
        private readonly BatchDto batchDto;
        private readonly Batch batch1;
        private readonly Batch batch2;
        private readonly List<Batch> batchList1;
        private readonly List<Batch> batchList2;
        private Guid batchId1 = Guid.NewGuid();
        private Guid batchId2 = Guid.NewGuid();
        private Guid teacherId1 = Guid.NewGuid();
        private Guid teacherId2 = Guid.NewGuid();

        public BatchControllerTest()
        {
            _mockBatchServices = new Mock<IBatchServices>();
            _controller = new BatchController(_mockBatchServices.Object);

            batchDto = new BatchDto
            {
                Name = "First",
                Code = "1",
                IsActive = true,
                TeacherId = teacherId1
            };

            batch1 = new Batch
            {
                Id = batchId1,
                Name = "First",
                Code = "1",
                IsActive = true,
                TeacherId = teacherId1,
                ClassCategories = null,
                ClassStreams = null,
                ClassRanks = null
            };

            batch2 = new Batch
            {
                Id = batchId2,
                Name = "Second",
                Code = "2",
                IsActive = false,
                TeacherId = teacherId2,
                ClassCategories = null,
                ClassStreams = null,
                ClassRanks = null
            };

            batchList1 = new List<Batch>()
            {
                batch1,
            };

            batchList2 = new List<Batch>()
            {
                batch1,
                batch2
            };
        }


        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [InlineData(null)]
        public async Task GetAllBatches_ReturnOkResult_WithListOfBatches(bool? isActive)
        {
            var objList = new List<Batch>();

            if (isActive.HasValue && isActive.Value)
            {
                objList = batchList1;
            }
            else
            {
                objList = batchList2;
            }

            _mockBatchServices.Setup(s => s.GetAllService(isActive)).ReturnsAsync(objList.AsEnumerable());

            var result = await _controller.GetAllBatches(isActive);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Batch>>(okResult.Value);
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
        public async Task GetBatchById_ReturnOkResult_WithBatchObject()
        {
            _mockBatchServices.Setup(s => s.GetByIdService(batchId1)).ReturnsAsync(batch1);

            var result = await _controller.GetBatchById(batchId1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Batch>(okResult.Value);
            Assert.Equal(batchId1, returnValue.Id);
            Assert.Equal(batch1, returnValue);
        }

        [Fact]
        public async Task CreateBatch_ReturnOkResult_WithBoolValueTrue()
        {
            _mockBatchServices.Setup(s => s.CreateService(batchDto)).ReturnsAsync(true);

            var result = await _controller.CreateBatch(batchDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task UpdateBatch_ReturnOkResult_WithBoolValueTrue()
        {
            _mockBatchServices.Setup(s => s.UpdateService(batchId1, batchDto)).ReturnsAsync(true);

            var result = await _controller.UpdateBatch(batchId1, batchDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task DeleteBatch_ReturnOkResult_WithBoolValueTrue()
        {
            _mockBatchServices.Setup(s => s.DeleteService(batchId1)).ReturnsAsync(true);

            var result = await _controller.DeleteBatch(batchId1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

    }
}