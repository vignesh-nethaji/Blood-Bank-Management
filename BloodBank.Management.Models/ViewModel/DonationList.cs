using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBank.Management.Models.ViewModel
{
    public class DonationList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Donor")]
        public string Donor { get; set; }
        public string BloodGroup { get; set; }
        [Required]
        [Display(Name = "Recipient")]
        public string Recipient { get; set; }
        [Required]
        [Display(Name = "Donation Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DonationDate { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
