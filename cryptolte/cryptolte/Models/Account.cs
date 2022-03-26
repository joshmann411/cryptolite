using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Models
{
    public class Account
    {
        [Key]
        public int AccoutId { get; set; }
        public string Email { get; set; } //a distinct email mapped to each use  account
        public string accType { get; set; }
        public string AccoutName { get; set; }
        public double CurrentAmount { get; set; } //remaining amount after purchases
        public string wallet { get; set; }
        public bool confirmed { get; set; }
        public int clientId { get; set; } //link to the  clients table
        
        public bool? isConfirmed { get; set; } = false;

        public DateTime? creationDate { get; set; } = DateTime.Now;
    }

    //enum AccountType
    //{
    //    Standard,
    //    Standrd-Cent
    //}

    public class AccountType
    {
        [Key]
        public int TypeId { get; set; }
        public string AccType { get; set; }
        public double MinDeposit { get; set; }
    }

    //public enum AccountType
    //{
    //    Standard,
    //    Cent,
    //    pro
    //}
}
