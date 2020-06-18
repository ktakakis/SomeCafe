using Microsoft.EntityFrameworkCore.Migrations;

namespace Mondays.DataAccess.Migrations
{
    public partial class Sweeteners3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "CustomerPreferences",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "CustomerPreferences");
        }
    }
}
