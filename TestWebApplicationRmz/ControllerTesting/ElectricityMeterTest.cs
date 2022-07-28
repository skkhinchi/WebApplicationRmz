//using FakeItEasy;
//using FluentAssertions;
//using Microsoft.AspNetCore.Mvc;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WebApplicationRmz.Controllers;
//using WebApplicationRmz.Data;
//using WebApplicationRmz.Models;
//using WebApplicationRmz.Service.ElectricityMeterService;
//using Xunit;

//namespace TestWebApplicationRmz.ControllerTesting
//{
//    public class ElectricityMeterTest
//    {
//        //private readonly ElectricityMeterController _controller;
//        //private readonly IElectricityMeterService _service;
//        private readonly ElectricityMeterService _meterService;
//      // ElectricityMeterController _controller = new ElectricityMeterController(new ElectricityMeterServiceFake());
       
      

//        [Fact]
//        public void ElectricityMeterControllerTest_ReturnSuccess()
//        {
//            //Arrange
//            var meterInfo = A.Fake<ICollection<ElectricityMeter>>();
//            var meterInfoList = A.Fake<List<ElectricityMeter>>();
//            var controller = new ElectricityMeterController(_meterService);
        
//            //Act
//            var result = controller.GetAll();

//            //Assert
//            result.Should().NotBeNull();
//            result.Should().BeOfType(typeof(OkObjectResult));

//        }






//    }
//}
