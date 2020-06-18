using Microsoft.EntityFrameworkCore.Migrations;

namespace Mondays.DataAccess.Migrations
{
    public partial class Sweeteners2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MilkTypeId",
                table: "CustomerPreferences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToppingId",
                table: "CustomerPreferences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPreferences_MilkTypeId",
                table: "CustomerPreferences",
                column: "MilkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPreferences_ToppingId",
                table: "CustomerPreferences",
                column: "ToppingId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPreferences_MilkTypes_MilkTypeId",
                table: "CustomerPreferences",
                column: "MilkTypeId",
                principalTable: "MilkTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPreferences_Toppings_ToppingId",
                table: "CustomerPreferences",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPreferences_MilkTypes_MilkTypeId",
                table: "CustomerPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPreferences_Toppings_ToppingId",
                table: "CustomerPreferences");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPreferences_MilkTypeId",
                table: "CustomerPreferences");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPreferences_ToppingId",
                table: "CustomerPreferences");

            migrationBuilder.DropColumn(
                name: "MilkTypeId",
                table: "CustomerPreferences");

            migrationBuilder.DropColumn(
                name: "ToppingId",
                table: "CustomerPreferences");
        }
    }
}
