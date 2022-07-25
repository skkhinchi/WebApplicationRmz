using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationRmz.Models
{
    public class Building
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BId { get; set; }
        public string BName { get; set; }
        [ForeignKey("FId")]
        public int FId { get; set; }
      
       // public Facility Facility { get; set; }


    }
}
