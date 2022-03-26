using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Models
{
    public class TransactionOnAccount
    {
        [Key]
        public int ToAId { get; set; }
        public double BalanceBroughtForward { get; set; } //Latest balance
        public double AvailableBalance { get; set; } //balance after manipulation
        [Required]
        public DateTime TransactionDate { get; set; }
        public bool Confirmation { get; set; }
    }
}
