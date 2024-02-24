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
        //[ForeignKey("BloodGroup")]
        //[Required]
        public int BloodGroupId { get; set; }
        //[ForeignKey("Hospital")]
        //[Required]
        public int HospitalId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        //public BloodGroup BloodGroup { get; set; }
        //public Hospital Hospital { get; set; }
        //public ICollection<Donation> Donations { get; set; }
    }
}
