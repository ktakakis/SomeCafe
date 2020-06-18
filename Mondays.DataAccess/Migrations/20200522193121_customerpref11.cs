using Microsoft.EntityFrameworkCore.Migrations;

namespace Mondays.DataAccess.Migrations
{
    public partial class customerpref11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IceCubeId",
                table: "CustomerPreferences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OriginId",
                table: "CustomerPreferences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPreferences_IceCubeId",
                table: "CustomerPreferences",
                column: "IceCubeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPreferences_OriginId",
                table: "CustomerPreferences",
                column: "OriginId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPreferences_IceCubes_IceCubeId",
                table: "CustomerPreferences",
                column: "IceCubeId",
                principalTable: "IceCubes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPreferences_Origins_OriginId",
                table: "CustomerPreferences",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPreferences_IceCubes_IceCubeId",
                table: "CustomerPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPreferences_Origins_OriginId",
                table: "CustomerPreferences");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPreferences_IceCubeId",
                table: "CustomerPreferences");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPreferences_OriginId",
                table: "CustomerPreferences");

            migrationBuilder.DropColumn(
                name: "IceCubeId",
                table: "CustomerPreferences");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "CustomerPreferences");
        }
    }
}
