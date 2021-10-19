using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Models.Auth
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        //public string Role { get; set; }

        //public string ClaimTitle { get; set; }
    }
}
