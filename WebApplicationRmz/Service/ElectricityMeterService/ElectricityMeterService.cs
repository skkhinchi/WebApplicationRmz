using System.Collections.Generic;
using System.Linq;
using WebApplicationRmz.Data;
using WebApplicationRmz.Model;
using WebApplicationRmz.Models;

namespace WebApplicationRmz.Service.ElectricityMeterService
{
    public class ElectricityMeterService : IElectricityMeterService
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public ElectricityMeterService(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

      

        public ElectricityMeter AddElectricityMeter(ElectricityMeter electricityMeter)
        {
            _ApplicationDbContext.ElectricityMeters.Add(electricityMeter);
            _ApplicationDbContext.SaveChanges();
            return electricityMeter;
        }

        //public void Delete(int id)
        //{
        //    throw new System.NotImplementedException();
        //}

        public IEnumerable<ElectricityMeter> GetAll()
        {
            return _ApplicationDbContext.ElectricityMeters;
        }

        public ElectricityMeter GetElectricityMeterById(int id)
        {
            return _ApplicationDbContext.ElectricityMeters.FirstOrDefault(c => c.EId == id);
        }

        public ElectricityMeterDetails GetMeterDetails(int id)
        {
            var MeterData = (from e in _ApplicationDbContext.ElectricityMeters
                             join z in _ApplicationDbContext.Zones on e.ZId equals z.ZId
                             // join b in _ApplicationDbContext.Buildings on z.BId equals b.BId
                             //join f in _ApplicationDbContext.Facilites on b.FId equals f.FId

                             select new ElectricityMeterDetails()
                             {
                                 MeterId = id,
                                 MeterReading = e.Reading,
                                 ZoneName = z.ZName,
                                 //BuildingName = b.BName,
                                 //FacilityName = f.FName
                             }).ToList();

            return MeterData.FirstOrDefault(c => c.MeterId == id);


        }

    }
}
