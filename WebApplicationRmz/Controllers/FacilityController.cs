using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplicationRmz.Data;
using WebApplicationRmz.Model;
using WebApplicationRmz.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationRmz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
       
        private readonly ApplicationDbContext _ApplicationDbContext;

        public FacilityController(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        public FacilityController()
        {
        }

        [HttpGet("GetAll")]
        public IEnumerable<Facility> GetAll()
        {
            return _ApplicationDbContext.Facilites;
        }


        [HttpGet("{id}")]
        public Facility GetSingle(int id)
        {
            return _ApplicationDbContext.Facilites.FirstOrDefault(c => c.FId == id);
        }

        [HttpPost]
        public void AddFacility ([FromBody ]Facility facility)
        {
            _ApplicationDbContext.Facilites.Add(facility);
            _ApplicationDbContext.SaveChanges();

        }


        [HttpPut("{id}")]
        public void Put([FromBody] Facility facility)
        {
            _ApplicationDbContext.Facilites.Update(facility);
            _ApplicationDbContext.SaveChanges();

        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _ApplicationDbContext.Facilites.SingleOrDefault(x => x.FId == id);
            if (item != null)
            {
                _ApplicationDbContext.Facilites.Remove(item);
                _ApplicationDbContext.SaveChanges();
            }
        }

        [HttpGet("GetFacilityByBId/{id}")]
        public BuildingWithFacility GetFacilityByBuildingId(int id)
        {
            // var x= _ApplicationDbContext.Buildings.FirstOrDefault(c => c.FId == id);
            var BuildingList = (from b in _ApplicationDbContext.Buildings
                                join f in _ApplicationDbContext.Facilites on b.FId equals f.FId
                                select new BuildingWithFacility()
                                {
                                    BuildngId = b.BId,
                                    BuilingName = b.BName,
                                    FacilityName = f.FName,
                                }).ToList();

            return BuildingList.FirstOrDefault(c => c.BuildngId == id);

            //return BuildingList;

        }




    }
}
