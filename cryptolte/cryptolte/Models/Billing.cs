using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Models
{
    public class Billing
    {
        [Key]
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
        
        public string Address { get; set; }
        
        public string Phone { get; set; }

        [Required]
        public string LinkedAccount { get; set; } //client id fk

    }

    public class BillingAddressDataModel
    {
        public int BillingId { get; set; }
        public string ClientId { get; set; }
        public string Address { get; set; }
    }
}
