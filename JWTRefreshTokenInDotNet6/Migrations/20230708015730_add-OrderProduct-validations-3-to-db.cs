using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PET.Migrations
{
    public partial class addOrderProductvalidations3todb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_OrderProducts_OrderProductId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_OrderProductId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderProductId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "OrderProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductsId",
                table: "OrderProducts",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Product_ProductsId",
                table: "OrderProducts",
                column: "ProductsId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Product_ProductsId",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_ProductsId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "OrderProducts");

            migrationBuilder.AddColumn<int>(
                name: "OrderProductId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderProductId",
                table: "Product",
                column: "OrderProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_OrderProducts_OrderProductId",
                table: "Product",
                column: "OrderProductId",
                principalTable: "OrderProducts",
                principalColumn: "Id");
        }
    }
}
