//using FakeItEasy;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WebApplicationRmz.Controllers;
//using WebApplicationRmz.Data;
//using WebApplicationRmz.Models;

//namespace TestWebApplicationRmz.ControllerTesting
//{
//    internal class FacilityControllerTests
//    {
//        private readonly ApplicationDbContext _ApplicationDbContext;

//        public FacilityControllerTests(ApplicationDbContext ApplicationDbContext)
//        {
//            _ApplicationDbContext = ApplicationDbContext;
//        }

//        private readonly List<Facility> _facility;

//        FacilityController facilityController = new FacilityController();
    
//        public void TestForGetAllFacility()
//        {
//            var dataStore = A.Fake<IEnumerable<Facility>>();
//            var expected =_ApplicationDbContext.Facilites;
//            var actual = facilityController.GetAll();
//            var count = actual.Count();
//            Assert.AreEqual(expected.Count(), count);
//            Assert.Equals(expected, actual);
//        }

//    }
//}
