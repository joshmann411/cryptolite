﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cryptolte.Models;

namespace cryptolte.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("cryptolte.Models.Account", b =>
                {
                    b.Property<int>("AccoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccoutName")
                        .HasColumnType("longtext");

                    b.Property<double>("CurrentAmount")
                        .HasColumnType("double");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("accType")
                        .HasColumnType("longtext");

                    b.Property<int>("clientId")
                        .HasColumnType("int");

                    b.Property<bool>("confirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("wallet")
                        .HasColumnType("longtext");

                    b.HasKey("AccoutId");

                    b.ToTable("accounts");

                    b.HasData(
                        new
                        {
                            AccoutId = 1,
                            AccoutName = "First Test",
                            CurrentAmount = 1000.0,
                            Email = "firstest@gmail,com",
                            accType = "Pro",
                            clientId = 1,
                            confirmed = false,
                            wallet = "et4yhtbveg4h576yujrb5gh7yh"
                        },
                        new
                        {
                            AccoutId = 2,
                            AccoutName = "Second Test",
                            CurrentAmount = 1000.0,
                            Email = "secondTest@gmail,com",
                            accType = "Standard",
                            clientId = 2,
                            confirmed = false,
                            wallet = "iueyrvg4hj5t5847eudyhfn5jk43e87u"
                        });
                });

            modelBuilder.Entity("cryptolte.Models.AccountType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccType")
                        .HasColumnType("longtext");

                    b.Property<double>("MinDeposit")
                        .HasColumnType("double");

                    b.HasKey("TypeId");

                    b.ToTable("accountType");

                    b.HasData(
                        new
                        {
                            TypeId = 1,
                            AccType = "Standard",
                            MinDeposit = 250.0
                        },
                        new
                        {
                            TypeId = 2,
                            AccType = "Standard-Cent",
                            MinDeposit = 150.0
                        },
                        new
                        {
                            TypeId = 3,
                            AccType = "Pro",
                            MinDeposit = 1000.0
                        });
                });

            modelBuilder.Entity("cryptolte.Models.Billing", b =>
                {
                    b.Property<int>("BillingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CCNumber")
                        .IsRequired()
                        .HasMaxLength(19)
                        .HasColumnType("varchar(19)");

                    b.Property<int>("Cvv")
                        .HasColumnType("int");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NameOnCard")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("BillingId");

                    b.ToTable("billings");

                    b.HasData(
                        new
                        {
                            BillingId = 1,
                            Address = "123 Test Street, YouknowWhatItIs Road",
                            CCNumber = "1234567123456746274",
                            Cvv = 123,
                            Expiration = new DateTime(2022, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NameOnCard = "John Doe",
                            Phone = "12345678909876"
                        },
                        new
                        {
                            BillingId = 2,
                            Address = "321 Test Street, yemen avenue",
                            CCNumber = "3589876543456787654",
                            Cvv = 321,
                            Expiration = new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NameOnCard = "Eric Klapson",
                            Phone = "87654345678"
                        });
                });

            modelBuilder.Entity("cryptolte.Models.Client", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("dateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .HasColumnType("longtext");

                    b.Property<string>("firstname")
                        .HasColumnType("longtext");

                    b.Property<string>("gender")
                        .HasColumnType("longtext");

                    b.Property<string>("lastname")
                        .HasColumnType("longtext");

                    b.Property<string>("maritalStatus")
                        .HasColumnType("longtext");

                    b.Property<string>("phone")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("clients");

                    b.HasData(
                        new
                        {
                            id = 1,
                            address = "123 Yemen str Florida",
                            dateOfBirth = new DateTime(1990, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "j@j.com",
                            firstname = "John",
                            gender = "Male",
                            lastname = "Doe",
                            maritalStatus = "Single",
                            phone = "1234567889"
                        },
                        new
                        {
                            id = 2,
                            address = "123 NY road New York",
                            dateOfBirth = new DateTime(1987, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "k@k.com",
                            firstname = "Kris",
                            gender = "Male",
                            lastname = "Olaku",
                            maritalStatus = "Single",
                            phone = "1234567889"
                        });
                });

            modelBuilder.Entity("cryptolte.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cell")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Firstname")
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext");

                    b.HasKey("ContactId");

                    b.ToTable("contacts");

                    b.HasData(
                        new
                        {
                            ContactId = 1,
                            Cell = "+1234567654",
                            Email = "johndoe@test.com",
                            Firstname = "John",
                            Surname = "Doe"
                        },
                        new
                        {
                            ContactId = 2,
                            Cell = "+27987654",
                            Email = "ericmiller@test.com",
                            Firstname = "Eric",
                            Surname = "Miller"
                        });
                });

            modelBuilder.Entity("cryptolte.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Amount")
                        .HasColumnType("longtext");

                    b.Property<string>("Asset")
                        .HasColumnType("longtext");

                    b.Property<int?>("ContactDetailsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfPurchase")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("purchases");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = "10.00",
                            Asset = "bitcoin",
                            ContactDetailsId = 1,
                            DateOfPurchase = new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            Id = 2,
                            Amount = "101.00",
                            Asset = "bitcoin",
                            DateOfPurchase = new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Local)
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
