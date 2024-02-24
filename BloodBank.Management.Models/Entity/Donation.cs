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
        //[ForeignKey("Donor")]
        //[Required]
        public int DonorId { get; set; }
        //[ForeignKey("Recipient")]
        //[Required]
        public int RecipientId { get; set; }
        public DateTime DonationDate { get; set; }
        public int Quantity { get; set; }

        //public Donor Donor { get; set; }
        //public Recipient Recipient { get; set; }
    }
}
