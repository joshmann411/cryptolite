using Microsoft.EntityFrameworkCore.Migrations;

namespace cryptolte.Migrations
{
    public partial class UpdateAccNameForBetterConvention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Account",
                table: "purchases",
                newName: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "purchases",
                newName: "Account");
        }
    }
}
