using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Management.Models.Entity
{
    public class Donation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Donor")]
        public int DonorId { get; set; }
        [Required]
        [Display(Name = "Recipient")]
        public int RecipientId { get; set; }
        [Required]
        [Display(Name = "Donation Date")]
        public DateTime DonationDate { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
