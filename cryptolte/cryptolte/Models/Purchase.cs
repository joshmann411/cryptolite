using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        public string Asset { get; set; }
        public int? ContactDetailsId { get; set; } //maps to clientId
        public string Amount { get; set; } //this should be followed by a well detailed message and possibly an email
        public string AccountId { get; set; } //account id: foreign key to the accounts table
        public DateTime DateOfPurchase { get; set; }
    }
}
