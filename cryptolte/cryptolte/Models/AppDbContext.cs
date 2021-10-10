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
        private readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration, 
                            DbContextOptions<AppDbContext> options) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Contact> contacts { get; set; }
        public DbSet<Purchase> purchases { get; set; }

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
                    Amount = "10.00",
                    Asset = _configuration.GetSection("crypto").Value.Split(",")[0] ?? "bitcoin",
                    ContactDetailsId = 1
                },
                new Purchase
                {
                    Id = 2,
                    Amount = "101.00",
                    Asset = _configuration.GetSection("crypto").Value.Split(",")[2] ?? "bitcoin",
                    ContactDetailsId = 2
                });
        }
    }
}
