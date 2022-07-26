using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplicationRmz.Data;
using WebApplicationRmz.Models;
using System.Linq;
using WebApplicationRmz.Model;
using WebApplicationRmz.Service.ElectricityMeterService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationRmz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricityMeterController : ControllerBase
    {

       
        private readonly IElectricityMeterService _service;

        public ElectricityMeterController(IElectricityMeterService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var items = _service.GetAll();
            return Ok(items);
        }


        [HttpGet("MeterDetailsById/{id}")]
        public IActionResult GetMeterDetails(int id)
        {
            //var MeterData = (from e in _ApplicationDbContext.ElectricityMeters
            //                join z in _ApplicationDbContext.Zones on e.ZId equals z.ZId
            //                // join b in _ApplicationDbContext.Buildings on z.BId equals b.BId
            //                 //join f in _ApplicationDbContext.Facilites on b.FId equals f.FId

            //                 select new ElectricityMeterDetails()
            //                {
            //                    MeterId = id,
            //                    MeterReading=e.Reading,
            //                    ZoneName = z.ZName,
            //                    //BuildingName = b.BName,
            //                    //FacilityName = f.FName
            //                }).ToList();

            //return MeterData.FirstOrDefault(c => c.MeterId == id);
            var items = _service.GetMeterDetails(id);
            return Ok(items);


        }



        //[HttpGet("{id}")]
        //public ElectricityMeter GetSingle(int id)
        //{
        //    return _ApplicationDbContext.ElectricityMeters.FirstOrDefault(c => c.EId == id);
        //}

        //[HttpPost]
        //public void AddElectricityMeter([FromBody] ElectricityMeter electricityMeters)
        //{
        //    _ApplicationDbContext.ElectricityMeters.Add(electricityMeters);
        //    _ApplicationDbContext.SaveChanges();

        //}


        //[HttpPut("{id}")]
        //public void Put([FromBody] ElectricityMeter electricityMeter)
        //{
        //    _ApplicationDbContext.ElectricityMeters.Update(electricityMeter);
        //    _ApplicationDbContext.SaveChanges();

        //}


        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    var item = _ApplicationDbContext.ElectricityMeters.SingleOrDefault(x => x.EId == id);
        //    if (item != null)
        //    {
        //        _ApplicationDbContext.ElectricityMeters.Remove(item);
        //        _ApplicationDbContext.SaveChanges();
        //    }
        //}
    }
}
