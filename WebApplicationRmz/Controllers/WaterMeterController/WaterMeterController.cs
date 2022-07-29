using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplicationRmz.Data;
using WebApplicationRmz.Models;
using System.Linq;
using WebApplicationRmz.Model;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationRmz.Controllers.WaterMeterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterMeterController : ControllerBase
    {

        private readonly ApplicationDbContext _ApplicationDbContext;

        public WaterMeterController(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        [HttpGet("GetAll")]
        public IEnumerable<WaterMeter> GetAll()
        {
            return _ApplicationDbContext.WaterMeters;
        }


        [HttpGet("MeterDetailsId/{id}")]
        public ElectricityMeterDetails GetMeterDetails(Guid id)
        {
            var MeterData = (from e in _ApplicationDbContext.WaterMeters
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

            //return BuildingList;

        }




        // GET: api/<WaterMeterController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<WaterMeterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void AddWaterMeter([FromBody] WaterMeter waterMeter)
        {
            _ApplicationDbContext.WaterMeters.Add(waterMeter);
            _ApplicationDbContext.SaveChanges();

        }

        // PUT api/<ElectricityMeterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WaterMeterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
