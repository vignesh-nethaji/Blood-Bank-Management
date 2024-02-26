using BloodBank.Management.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Management.Models.ViewModel
{
    public class DonarList
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Display(Name = "Last Donation")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastDonationDate { get; set; }
    }
}
