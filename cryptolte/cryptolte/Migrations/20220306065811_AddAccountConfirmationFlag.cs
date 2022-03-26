using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cryptolte.Migrations
{
    public partial class AddAccountConfirmationFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isConfirmed",
                table: "accounts",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "AccoutId",
                keyValue: 1,
                column: "isConfirmed",
                value: true);

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "AccoutId",
                keyValue: 2,
                column: "isConfirmed",
                value: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isConfirmed",
                table: "accounts");

            migrationBuilder.UpdateData(
                table: "purchases",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfPurchase",
                value: new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "purchases",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfPurchase",
                value: new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
