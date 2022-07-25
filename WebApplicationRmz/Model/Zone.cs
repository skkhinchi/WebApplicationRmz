using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationRmz.Models
{
    public class Zone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ZId { get; set; }
        public string ZName { get; set; }

        [ForeignKey("FId")]
        public int FId { get; set; }

      
        // public Facility Facility { get; set; }
        [ForeignKey("BId")]
        public int BId { get; set; }

       
       // public Building Building { get; set; }

    }
}
