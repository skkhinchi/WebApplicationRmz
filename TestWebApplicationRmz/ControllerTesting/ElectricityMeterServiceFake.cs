//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WebApplicationRmz.Model;
//using WebApplicationRmz.Models;
//using WebApplicationRmz.Service.ElectricityMeterService;

//namespace TestWebApplicationRmz.ControllerTesting
//{
//    public class ElectricityMeterServiceFake : IElectricityMeterService
//    {

//        private readonly List<ElectricityMeter> electricityMeter;
//        public ElectricityMeterServiceFake()
//        {
//            electricityMeter = new List<ElectricityMeter>()
//            {
//                new ElectricityMeter() { FId = new int(),
//                    Reading = 2323, BId= 1, EId=1, ZId=2},

//               new ElectricityMeter() { FId = new int(),
//                    Reading = 23243, BId= 2, EId=5, ZId=1},

//               new ElectricityMeter() { FId = new int(),
//                    Reading = 233223, BId= 3, EId=4, ZId=2},
//            };
//        }

//        public ElectricityMeter GetElectricityMeterById(int id)
//        {
//            return electricityMeter.Where(a => a.EId == id)
//           .FirstOrDefault();
//        }

//        public void Delete(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public ElectricityMeterDetails GetMeterDetails(int id)
//        {
//            throw new NotImplementedException();
//        }


//        public IEnumerable<ElectricityMeter> GetAll()
//        {
//            return electricityMeter;
//        }

//        public ElectricityMeter AddElectricityMeter(ElectricityMeter electricityMeter)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
