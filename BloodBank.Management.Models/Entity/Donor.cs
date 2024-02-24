using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Management.Models.Entity
{
    /// <summary>
    /// 
    /// </summary>
   public  class Donor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[ForeignKey("BloodGroup")]
        //[Required]
        public int BloodGroupId { get; set; }
        public string  Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string  Address { get; set; }
        public DateTime LastDonationDate  { get; set; }

        //public BloodGroup BloodGroup { get; set; }
        //public ICollection<Donation> Donations { get; set; }
        //public ICollection<Inventory> Inventorys { get; set; }
    }
}
