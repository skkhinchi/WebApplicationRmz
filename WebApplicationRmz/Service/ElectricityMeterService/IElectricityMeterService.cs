using System.Collections.Generic;
using WebApplicationRmz.Model;
using WebApplicationRmz.Models;

namespace WebApplicationRmz.Service.ElectricityMeterService
{
    public interface IElectricityMeterService
    {
        //  List<ElectricityMeter> GetAll();
        // List<ElectricityMeter> GetElectricityMeterById(int id);
        //List<ElectricityMeter> AddElectricityMeter(ElectricityMeter electricityMeter);

        IEnumerable<ElectricityMeter> GetAll();
        ElectricityMeter AddElectricityMeter(ElectricityMeter electricityMeter);
        ElectricityMeter GetElectricityMeterById(int id);
      //  void Delete(int id);
        ElectricityMeterDetails GetMeterDetails(int id);


    }
}
