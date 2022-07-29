using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApplicationRmz.ControllerTesting.ElectricityControllersTest;
using WebApplicationRmz.Controllers;
using WebApplicationRmz.Controllers.ElectricityMeterController;
using WebApplicationRmz.Model;
using WebApplicationRmz.Models;
using WebApplicationRmz.Service.ElectricityMeterService;
using Xunit;

namespace TestWebApplicationRmz.ControllerTesting
{
    public class ElectricityMeterControllerTest
    {
        private readonly ElectricityMeterController _controller;
        private readonly IElectricityMeterService _service;

        public ElectricityMeterControllerTest()
        {
            _service = new ElectricityMeterServiceFake();
            _controller = new ElectricityMeterController(_service);
        }


        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get() as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<ElectricityMeter>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }






        //[Fact]
        //public void ElectricityMeterControllerTest_ReturnSuccess()
        //{
        //    //Arrange
        //    //FakeitEasy
        //    var meterInfo = A.Fake<ICollection<ElectricityMeter>>();
        //    var meterInfoList = A.Fake<List<ElectricityMeter>>();
        //   // var controller = new ElectricityMeterController(_controller);

        //    //Act
        //    var result = _service.GetAllItems();

        //    //Assert
        //    result.Should().NotBeNull();
        //    result.Should().BeOfType(typeof(OkObjectResult));

        //}




        //----------------------------------------

        [Fact]
        public void ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void ReturnsOkResultWhenGuidRight()
        {
            // Arrange
            var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Act
            var okResult = _controller.Get(testGuid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void ReturnsNotNullWhenGuidRight()
        {
            // Arrange
            var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Act
            var okResult = _controller.Get(testGuid);

            // Assert
            Assert.NotNull(okResult);
        }

        //------------------------------
        [Fact]
        public void ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new ElectricityMeter()
            {
                Reading = "Guinness",
                FId = 23,
            };
            _controller.ModelState.AddModelError("Reading", "Required");

            // Act
            var badResponse = _controller.Post(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            ElectricityMeter testItem = new ElectricityMeter()
            {
               
                Reading = "Guinness Original 6 Pack",
                FId = 2,
                BId= 2,
                ZId=1,

            };

            // Act
            var createdResponse = _controller.Post(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new ElectricityMeter()
            {
                Reading = "Guinness Original 6 Pack",
                FId = 1,
                BId = 1,
                ZId = 1,
            };

            // Act
            var createdResponse = _controller.Post(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as ElectricityMeter;

            // Assert
            Assert.IsType<ElectricityMeter>(item);
            Assert.Equal("Guinness Original 6 Pack", item.Reading);
        }










    }
}
