using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Management.Models.Entity
{
   public  class Hospital
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Hospital name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Hostpital location is required")]
        public string  Location { get; set; }
        [Required(ErrorMessage = "Hospital contact no is required")]
        public string  Mobile { get; set; }
        //public ICollection<Recipient> Recipients { get; set; }
    }
}
