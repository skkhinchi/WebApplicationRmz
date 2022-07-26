using Microsoft.EntityFrameworkCore;
using WebApplicationRmz.Model;
using WebApplicationRmz.Models;

namespace WebApplicationRmz.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        } 


       
        public DbSet<ElectricityMeter> ElectricityMeters { get; set; }
        public DbSet<WaterMeter> WaterMeters { get; set; }
        public DbSet<Facility> Facilites { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Zone> Zones { get; set; }




    }
}
