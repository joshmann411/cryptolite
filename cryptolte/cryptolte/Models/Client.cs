using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Models
{
    public class Client
    {
        [Key]
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string maritalStatus { get; set; }
    }
}
