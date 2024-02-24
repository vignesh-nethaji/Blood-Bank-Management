using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBank.Management.Models.Entity
{
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[ForeignKey("Donor")]
        public int DonorId { get; set; }
        //[ForeignKey("BloodGroup")]
        //[Required]
        public int BloodGroupId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool Status { get; set; }

        //public Donor Donor { get; set; }
        //public BloodGroup BloodGroup { get; set; }

    }
}
