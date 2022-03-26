using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cryptolte.Migrations
{
    public partial class LinkAccountToCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkedAccount",
                table: "billings",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "billings",
                keyColumn: "BillingId",
                keyValue: 1,
                column: "LinkedAccount",
                value: "3");

            migrationBuilder.UpdateData(
                table: "billings",
                keyColumn: "BillingId",
                keyValue: 2,
                column: "LinkedAccount",
                value: "3");

            migrationBuilder.UpdateData(
                table: "purchases",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfPurchase",
                value: new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "purchases",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfPurchase",
                value: new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkedAccount",
                table: "billings");

            migrationBuilder.UpdateData(
                table: "purchases",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfPurchase",
                value: new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "purchases",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfPurchase",
                value: new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
