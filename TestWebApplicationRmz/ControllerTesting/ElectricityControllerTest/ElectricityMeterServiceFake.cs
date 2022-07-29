using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplicationRmz.Model;
using WebApplicationRmz.Models;
using WebApplicationRmz.Service.ElectricityMeterService;

namespace TestWebApplicationRmz.ControllerTesting.ElectricityControllersTest
{
    public class ElectricityMeterServiceFake : IElectricityMeterService
    {
        private readonly List<ElectricityMeter> _electricityMeters;

        public ElectricityMeterServiceFake()
        {
            _electricityMeters = new List<ElectricityMeter>()
            {
                new ElectricityMeter() { Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Reading = "321", FId=1, BId=2,ZId=2 },

                new ElectricityMeter() { Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                   Reading = "2321", FId=2, BId=1,ZId=1 },
                new ElectricityMeter() { Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                    Reading = "43521", FId=1, BId=1,ZId=1 },
            };
        }

        private readonly IElectricityMeterService _service;

        public ElectricityMeterServiceFake(IElectricityMeterService service)
        {
            _service = service;
        }


        IEnumerable<ElectricityMeter> IElectricityMeterService.GetAllItems()
        {
            return _electricityMeters;
        }

        public ElectricityMeter Add(ElectricityMeter newItem)
        {
            newItem.Id = Guid.NewGuid();
            _electricityMeters.Add(newItem);
            return newItem;
        }

        public ElectricityMeter GetById(Guid id)
        {
            return _electricityMeters.Where(a => a.Id == id)
                .FirstOrDefault();
        }

        //public ElectricityMeterDetails GetFullDetails(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public ElectricityMeterDetails GetFullDetails(Guid id)
        //{
        //    return _service.GetFullDetails(id);
        //}



        //public ShoppingItem GetById(Guid id)
        //{
        //    return _shoppingCart.Where(a => a.Id == id)
        //        .FirstOrDefault();
        //}

        //public void Remove(Guid id)
        //{
        //    var existing = _shoppingCart.First(a => a.Id == id);
        //    _shoppingCart.Remove(existing);
        //}

        //IEnumerable<ElectricityMeter> IElectricityMeterService.GetAllItems()
        //{
        //    throw new NotImplementedException();
        //}

        //public ElectricityMeter Add(ElectricityMeter newItem)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
