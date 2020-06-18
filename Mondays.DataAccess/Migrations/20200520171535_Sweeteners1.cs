using Microsoft.EntityFrameworkCore.Migrations;

namespace Mondays.DataAccess.Migrations
{
    public partial class Sweeteners1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SweetenerId",
                table: "CustomerPreferences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPreferences_SweetenerId",
                table: "CustomerPreferences",
                column: "SweetenerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPreferences_Sweeteners_SweetenerId",
                table: "CustomerPreferences",
                column: "SweetenerId",
                principalTable: "Sweeteners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPreferences_Sweeteners_SweetenerId",
                table: "CustomerPreferences");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPreferences_SweetenerId",
                table: "CustomerPreferences");

            migrationBuilder.DropColumn(
                name: "SweetenerId",
                table: "CustomerPreferences");
        }
    }
}
