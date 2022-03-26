using Microsoft.EntityFrameworkCore.Migrations;

namespace cryptolte.Migrations
{
    public partial class UpdatedAccountIdFKToPurchaseSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Account",
                table: "purchases",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "purchases",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Account", "Amount" },
                values: new object[] { "3", "50.00" });

            migrationBuilder.UpdateData(
                table: "purchases",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Account", "Amount" },
                values: new object[] { "3", "10.00" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Account",
                table: "purchases");

            migrationBuilder.UpdateData(
                table: "purchases",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: "10.00");

            migrationBuilder.UpdateData(
                table: "purchases",
                keyColumn: "Id",
                keyValue: 2,
                column: "Amount",
                value: "101.00");
        }
    }
}
