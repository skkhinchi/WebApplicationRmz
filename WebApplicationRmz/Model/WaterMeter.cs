using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationRmz.Models
{
    public class WaterMeter
    {
        [Key]
        public int WId { get; set; }
        public string Reading { get; set; }
       // public int FId { get; set; }
        [ForeignKey("FId")]
        public int FId { get; set; }
        //public Facility Facility { get; set; }

        // public int BId { get; set; }
        [ForeignKey("BId")]
        public int BId { get; set; }
        //public Building Building { get; set; }
        // public int ZId { get; set; }
        [ForeignKey("ZId")]
        public int ZId { get; set; }
        //public Zone Zone { get; set; }
    }
}
