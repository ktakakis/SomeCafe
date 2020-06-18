using Microsoft.EntityFrameworkCore.Migrations;

namespace Mondays.DataAccess.Migrations
{
    public partial class updateprefers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IceCubeId",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MilkTypeId",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OriginId",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SweetenerId",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SweetnessId",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToppingId",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SweetenerId",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_IceCubeId",
                table: "ShoppingCarts",
                column: "IceCubeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_MilkTypeId",
                table: "ShoppingCarts",
                column: "MilkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_OriginId",
                table: "ShoppingCarts",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_SweetenerId",
                table: "ShoppingCarts",
                column: "SweetenerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_SweetnessId",
                table: "ShoppingCarts",
                column: "SweetnessId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ToppingId",
                table: "ShoppingCarts",
                column: "ToppingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_IceCubes_IceCubeId",
                table: "ShoppingCarts",
                column: "IceCubeId",
                principalTable: "IceCubes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_MilkTypes_MilkTypeId",
                table: "ShoppingCarts",
                column: "MilkTypeId",
                principalTable: "MilkTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Origins_OriginId",
                table: "ShoppingCarts",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Sweeteners_SweetenerId",
                table: "ShoppingCarts",
                column: "SweetenerId",
                principalTable: "Sweeteners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Sweetness_SweetnessId",
                table: "ShoppingCarts",
                column: "SweetnessId",
                principalTable: "Sweetness",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Toppings_ToppingId",
                table: "ShoppingCarts",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_IceCubes_IceCubeId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_MilkTypes_MilkTypeId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Origins_OriginId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Sweeteners_SweetenerId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Sweetness_SweetnessId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Toppings_ToppingId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_IceCubeId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_MilkTypeId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_OriginId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_SweetenerId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_SweetnessId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_ToppingId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "IceCubeId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "MilkTypeId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "SweetenerId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "SweetnessId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "ToppingId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "SweetenerId",
                table: "OrderDetails");
        }
    }
}
