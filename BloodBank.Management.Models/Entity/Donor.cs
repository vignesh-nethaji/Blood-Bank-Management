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
    public class Donor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[ForeignKey("BloodGroup")]
        [Required]
        [Display(Name = "Blood Group")]
        public int BloodGroupId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Mobile { get; set; }
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Display(Name = "Last Donation")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime LastDonationDate { get; set; }

        //public BloodGroup BloodGroup { get; set; }
        //public ICollection<Donation> Donations { get; set; }
        //public ICollection<Inventory> Inventorys { get; set; }
    }
}
