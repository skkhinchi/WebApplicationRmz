using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationRmz.Models
{
    public class ElectricityMeter
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int EId { get; set; }

        //public double Reading { get; set; }


        //[ForeignKey("FId")]
        //public int FId { get; set; }


        //[ForeignKey("BId")]
        //public int BId { get; set; }


        //[ForeignKey("ZId")]
        //public int ZId { get; set; }


        public Guid Id { get; set; }
        [Required]
        public string Reading { get; set; }


        [ForeignKey("FId")]
        public int FId { get; set; }


        [ForeignKey("BId")]
        public int BId { get; set; }


        [ForeignKey("ZId")]
        public int ZId { get; set; }

    }
}
