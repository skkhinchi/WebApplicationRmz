using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationRmz.Controllers;
using WebApplicationRmz.Data;
using WebApplicationRmz.Models;

namespace TestWebApplicationRmz.ControllerTesting
{
    internal class ElectricityMeterTest
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public ElectricityMeterTest(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

         FacilityController facilityController = new FacilityController();

        public void GetAllElectricityMeterTest()
        {
            // Act
            var okResult = facilityController.GetAll() as OkObjectResult;

            var items = Assert.AreEqual<List<ElectricityMeter>>(okResult.Value);



            // Assert
            Assert.AreEqual<OkObjectResult>(okResult as OkObjectResult);
        }

    }
}
