using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBank.Management.Models.ViewModel
{
    public class RecipientList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }
        [Required]
        [Display(Name = "Hospital")]
        public string Hospital { get; set; }
        [Required(ErrorMessage = "Recipient name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Recipient contact no is required")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Recipient email id is required")]
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
