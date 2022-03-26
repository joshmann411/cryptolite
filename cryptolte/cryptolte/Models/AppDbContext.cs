using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Models
{
    public class AppDbContext : IdentityDbContext
    {
        //private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
          
        }

        //public AppDbContext(IConfiguration configuration, 
        //                    DbContextOptions<AppDbContext> options) : base(options)
        //{
        //    _configuration = configuration;
        //}

        public DbSet<Contact> contacts { get; set; }
        public DbSet<Purchase> purchases { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<AccountType> accountType { get; set; }
        public DbSet<Billing> billings { get; set; }
        public DbSet<Client> clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    Firstname = "John",
                    Surname = "Doe",
                    Email = "johndoe@test.com",
                    Cell = "+1234567654"
                },
                new Contact
                {
                    ContactId = 2,
                    Firstname = "Eric",
                    Surname = "Miller",
                    Email = "ericmiller@test.com",
                    Cell = "+27987654"
                });


            modelBuilder.Entity<Purchase>().HasData(
                new Purchase
                {
                    Id = 1,
                    Amount = "50.00",
                    Asset = "bitcoin",
                    //Asset = _configuration.GetSection("crypto").Value.Split(",")[0] ?? "bitcoin",
                    ContactDetailsId = 1,
                    AccountId = "3",
                    DateOfPurchase = DateTime.Today
                },
                new Purchase
                {
                    Id = 2,
                    Amount = "10.00",
                    Asset = "bitcoin",
                    AccountId = "3",
                    //Asset = _configuration.GetSection("crypto").Value.Split(",")[2] ?? "bitcoin",
                    DateOfPurchase = DateTime.Today
                });

            modelBuilder.Entity<Billing>().HasData(
                new Billing {
                    BillingId = 1,
                    NameOnCard = "John Doe",
                    CCNumber = "1234567123456746274",
                    Expiration = new DateTime(2022, 05, 14),
                    Cvv = 123,
                    Address = "123 Test Street, YouknowWhatItIs Road",
                    Phone = "12345678909876",
                    LinkedAccount = "3"
                },
                new Billing
                {
                    BillingId = 2,
                    NameOnCard = "Eric Klapson",
                    CCNumber = "3589876543456787654",
                    Expiration = new DateTime(2025, 07, 04),
                    Cvv = 321,
                    Address = "321 Test Street, yemen avenue",
                    Phone = "87654345678",
                    LinkedAccount = "3"
                });

            modelBuilder.Entity<AccountType>().HasData(
                new AccountType
                {
                    TypeId = 1,
                    AccType = "Standard",
                    MinDeposit = 250.00
                },
                new AccountType
                {
                    TypeId = 2,
                    AccType = "Standard-Cent",
                    MinDeposit = 150
                },
                new AccountType
                {
                    TypeId = 3,
                    AccType = "Pro",
                    MinDeposit = 1000
                });

            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    AccoutId = 1,
                    AccoutName = "First Test",
                    Email = "firstest@gmail,com",
                    accType = "Pro",
                    clientId = 1,
                    wallet = "et4yhtbveg4h576yujrb5gh7yh",
                    confirmed = false,
                    CurrentAmount = 1000,
                    isConfirmed = true
                },
                new Account
                {
                    AccoutId = 2,
                    AccoutName = "Second Test",
                    Email = "secondTest@gmail,com",
                    accType = "Standard",
                    clientId = 2,
                    wallet = "iueyrvg4hj5t5847eudyhfn5jk43e87u",
                    confirmed = false,
                    CurrentAmount = 1000,
                    isConfirmed = true
                });

            modelBuilder.Entity<Client>().HasData(
               new Client
               {
                   id = 1,
                   firstname = "John",
                   lastname = "Doe",
                   address = "123 Yemen str Florida",
                   email = "j@j.com",
                   dateOfBirth = new DateTime(1990, 07, 21),
                   gender = "Male",
                   maritalStatus = "Single",
                   phone = "1234567889"
               },
               new Client
               {
                   id = 2,
                   firstname = "Kris",
                   lastname = "Olaku",
                   address = "123 NY road New York",
                   email = "k@k.com",
                   dateOfBirth = new DateTime(1987, 03, 13),
                   gender = "Male",
                   maritalStatus = "Single",
                   phone = "1234567889"
               });
        }
    }
}
