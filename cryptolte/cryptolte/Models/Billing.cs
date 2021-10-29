using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Models
{
    public class Billing
    {
        public int BillingId { get; set; }
        [Required]
        public string NameOnCard { get; set; }
        [Required]
        [MaxLength(19, ErrorMessage = "Length cannot exceed 19")]
        [MinLength(10, ErrorMessage = "Length cannot be less than 19")]
        public string CCNumber { get; set; }
        [Required]
        public DateTime Expiration { get; set; }
        [Required]
        public int Cvv { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
