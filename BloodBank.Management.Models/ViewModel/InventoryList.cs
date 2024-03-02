using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBank.Management.Models.ViewModel
{
    public class InventoryList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Donor")]
        public string Donor { get; set; }
        [Required]
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }
        public int DonationId { get; set; }
        [Display(Name = "Recipient")]
        public string Recipient { get; set; }
        [Display(Name = "Expiry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime ExpiryDate { get; set; }
        public bool Status { get; set; }
    }
}
