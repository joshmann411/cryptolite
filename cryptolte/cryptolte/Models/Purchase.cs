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
        public Contact ContactDetails { get; set; }
        public string Amount { get; set; } //this should be followed by a well detailed message and possibly an email
    }
}
