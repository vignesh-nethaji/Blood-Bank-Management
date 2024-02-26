using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Management.Models.Entity
{
    public class Recipient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Blood Group")]
        public int BloodGroupId { get; set; }
        [Required]
        [Display(Name = "Hospital")]
        public int HospitalId { get; set; }
        [Required(ErrorMessage = "Recipient name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Recipient contact no is required")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Recipient email id is required")]
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
