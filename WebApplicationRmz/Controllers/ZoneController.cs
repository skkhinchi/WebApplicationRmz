using Microsoft.AspNetCore.Mvc;
using skkhinchi_Rmz_management.Models;
using System.Collections.Generic;
using WebApplicationRmz.Data;
using System.Linq;
using WebApplicationRmz.Model;
using WebApplicationRmz.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationRmz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController : ControllerBase
    {

        private readonly ApplicationDbContext _ApplicationDbContext;

        public ZoneController(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Zone> GetAll()
        {
            return _ApplicationDbContext.Zones;
        }


        [HttpGet("ZoneAllDetailsById/{id}")]
        public ZoneWithAllDetails GetZoneDetails(int id)
        {
            var ZoneList = (from z in _ApplicationDbContext.Zones
                            join b in _ApplicationDbContext.Buildings on z.BId equals b.BId
                            join f in _ApplicationDbContext.Facilites on b.FId equals f.FId
                            select new ZoneWithAllDetails()
                            {
                                ZoneId = id,
                                ZoneName = z.ZName,
                                BuildingName = b.BName,
                                FacilityName = f.FName
                            }).ToList();

            return ZoneList.FirstOrDefault(c => c.ZoneId == id);

            //return BuildingList;

        }



        [HttpGet("ZonesBuilingByZoneId/{id}")]
        public ZoneWithBuildingDetails GetBuilidingByZoneId(int id)
        {
            var ZoneList = (from z in _ApplicationDbContext.Zones
                            join b in _ApplicationDbContext.Buildings on z.BId equals b.BId
                            select new ZoneWithBuildingDetails()
                            {
                                ZoneId = id,
                                ZoneName = z.ZName,
                                BuildingName = b.BName,
                            }).ToList();

            return ZoneList.FirstOrDefault(c => c.ZoneId == id);


        }


        //[HttpGet("ZonesBuilingByZoneId/{id}")]
        //public ZoneWithBuildingDetails GetBuilidingByZoneId(int id)
        //{
        //    var ZoneList =  _ApplicationDbContext.Zones
        //                    .Join(_ApplicationDbContext.Buildings,
        //                    z=>z.ZId,
        //                    b =>b.ZId,
        //                    (z,b) => {z, b}
        //                    )
        //                    .Select(Response =>new ZoneWithBuildingDetails()
        //                    {

        //                    })

        //    return ZoneList.FirstOrDefault(c => c.ZoneId == id);

        //    //return BuildingList;

        //}






        [HttpGet("{id}")]
        public Zone GetSingle(int id)
        {
            return _ApplicationDbContext.Zones.FirstOrDefault(c => c.ZId == id);
        }

        [HttpPost]
        public void AddZone([FromBody] Zone zone)
        {
            _ApplicationDbContext.Zones.Add(zone);
            _ApplicationDbContext.SaveChanges();

        }


        [HttpPut("{id}")]
        public void Put([FromBody] Zone zone)
        {
            _ApplicationDbContext.Zones.Update(zone);
            _ApplicationDbContext.SaveChanges();
    
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _ApplicationDbContext.Zones.SingleOrDefault(x => x.ZId == id);
            if (item != null)
            {
                _ApplicationDbContext.Zones.Remove(item);
                _ApplicationDbContext.SaveChanges();
            }
        }
    }
}
