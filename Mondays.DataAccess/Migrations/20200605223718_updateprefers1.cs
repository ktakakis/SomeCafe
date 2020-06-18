using Microsoft.EntityFrameworkCore.Migrations;

namespace Mondays.DataAccess.Migrations
{
    public partial class updateprefers1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IceCubeId",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MilkTypeId",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OriginId",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SweetnessId",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToppingId",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_IceCubeId",
                table: "OrderDetails",
                column: "IceCubeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_MilkTypeId",
                table: "OrderDetails",
                column: "MilkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OriginId",
                table: "OrderDetails",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_SweetenerId",
                table: "OrderDetails",
                column: "SweetenerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_SweetnessId",
                table: "OrderDetails",
                column: "SweetnessId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ToppingId",
                table: "OrderDetails",
                column: "ToppingId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_IceCubes_IceCubeId",
                table: "OrderDetails",
                column: "IceCubeId",
                principalTable: "IceCubes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_MilkTypes_MilkTypeId",
                table: "OrderDetails",
                column: "MilkTypeId",
                principalTable: "MilkTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Origins_OriginId",
                table: "OrderDetails",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Sweeteners_SweetenerId",
                table: "OrderDetails",
                column: "SweetenerId",
                principalTable: "Sweeteners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Sweetness_SweetnessId",
                table: "OrderDetails",
                column: "SweetnessId",
                principalTable: "Sweetness",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Toppings_ToppingId",
                table: "OrderDetails",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_IceCubes_IceCubeId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_MilkTypes_MilkTypeId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Origins_OriginId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Sweeteners_SweetenerId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Sweetness_SweetnessId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Toppings_ToppingId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_IceCubeId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_MilkTypeId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OriginId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_SweetenerId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_SweetnessId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ToppingId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "IceCubeId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "MilkTypeId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "SweetnessId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ToppingId",
                table: "OrderDetails");
        }
    }
}
