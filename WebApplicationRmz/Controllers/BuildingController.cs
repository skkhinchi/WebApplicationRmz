using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplicationRmz.Data;
using WebApplicationRmz.Model;
using WebApplicationRmz.Models;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationRmz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {

        private readonly ApplicationDbContext _ApplicationDbContext;

        public BuildingController(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Building> GetAll()
        {
            return _ApplicationDbContext.Buildings;
        }


        [HttpGet("BuilingDetailsId/{id}")]
        public BuildingWithFacility GetBuildingDetails(int id)
        {
            var BuildingList = (from f in _ApplicationDbContext.Facilites
                                join b in _ApplicationDbContext.Buildings on f.FId equals b.FId
                                select new BuildingWithFacility()
                                {
                                    BuildngId = b.BId,
                                    BuilingName = b.BName,
                                    FacilityName = f.FName,
                                }).ToList();

            return BuildingList.FirstOrDefault(c => c.BuildngId == id);

            //return BuildingList;

        }



        [HttpGet("{id}")]
        public Building GetSingle(int id)
        {
            return _ApplicationDbContext.Buildings.FirstOrDefault(c => c.BId == id);
        }

        [HttpPost]
        public void AddBuilding([FromBody] Building building)
        {
            _ApplicationDbContext.Buildings.Add(building);
            _ApplicationDbContext.SaveChanges();

        }


        [HttpPut("{id}")]
        public void Put([FromBody] Building building)
        {
            _ApplicationDbContext.Buildings.Update(building);
            _ApplicationDbContext.SaveChanges();

        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _ApplicationDbContext.Buildings.SingleOrDefault(x => x.BId == id);
            if (item != null)
            {
                _ApplicationDbContext.Buildings.Remove(item);
                _ApplicationDbContext.SaveChanges();
            }
        }
    }
}
