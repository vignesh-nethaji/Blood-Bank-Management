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
        [Required]
        [Display(Name = "Donor")]
        public int DonorId { get; set; }
        [Required]
        [Display(Name = "Blood Group")]
        public int BloodGroupId { get; set; }
        public int DonationId { get; set; }
        [Display(Name = "Expiry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime ExpiryDate { get; set; }
        public bool Status { get; set; }
    }
}
