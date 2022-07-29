using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplicationRmz.Data;
using WebApplicationRmz.Models;
using System.Linq;
using WebApplicationRmz.Model;
using WebApplicationRmz.Service.ElectricityMeterService;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationRmz.Controllers.ElectricityMeterController
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

     
        [HttpGet]
        public IActionResult Get()
        {
            var items = _service.GetAllItems();
            return Ok(items);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ElectricityMeter value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _service.Add(value);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }


        //private readonly IElectricityMeterService _service;

        //public ElectricityMeterController(IElectricityMeterService service)
        //{
        //    _service = service;
        //}

        //public ElectricityMeterController()
        //{
        //}

        //[HttpGet("GetAll")]
        //public IActionResult GetAll()
        //{
        //    var items = _service.GetAll();
        //    return Ok(items);
        //}


        //[HttpGet("MeterFullDetailssById/{id}")]
        //public IActionResult GetMeterDetails(Guid id)
        //{

        //    var items = _service.GetFullDetails(id);
        //    return Ok(items);
        //}



        //[HttpGet("{id}")]
        //public ElectricityMeter GetSingle(int id)
        //{
        //    var items = _service.GetElectricityMeterById(id);
        //    return items;
        //}

        //[HttpPost]
        //public ElectricityMeter AddElectricityMeter([FromBody] ElectricityMeter electricityMeters)
        //{
        //    var items = _service.AddElectricityMeter(electricityMeters);
        //    return items;

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
