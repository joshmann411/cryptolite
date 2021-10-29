using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cryptolte.Migrations
{
    public partial class UpdateBillingSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "billings",
                columns: table => new
                {
                    BillingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOnCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCNumber = table.Column<string>(type: "nvarchar(19)", maxLength: 19, nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cvv = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_billings", x => x.BillingId);
                });

            migrationBuilder.InsertData(
                table: "billings",
                columns: new[] { "BillingId", "Address", "CCNumber", "Cvv", "Expiration", "NameOnCard", "Phone" },
                values: new object[] { 1, "123 Test Street, YouknowWhatItIs Road", "1234567123456746274", 123, new DateTime(2022, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", "12345678909876" });

            migrationBuilder.InsertData(
                table: "billings",
                columns: new[] { "BillingId", "Address", "CCNumber", "Cvv", "Expiration", "NameOnCard", "Phone" },
                values: new object[] { 2, "321 Test Street, yemen avenue", "3589876543456787654", 321, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eric Klapson", "87654345678" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "billings");
        }
    }
}
