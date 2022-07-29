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
        //    var meterInfo = A.Fake<ICollection<ElectricityMeter>>();
        //    var meterInfoList = A.Fake<List<ElectricityMeter>>();
        //    var controller = new ElectricityMeterController(_meterService);

        //    //Act
        //    var result = controller.GetAll();

        //    //Assert
        //    result.Should().NotBeNull();
        //    result.Should().BeOfType(typeof(OkObjectResult));

        //}






    }
}
