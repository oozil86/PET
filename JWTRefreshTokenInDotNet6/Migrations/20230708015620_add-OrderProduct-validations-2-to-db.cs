using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PET.Migrations
{
    public partial class addOrderProductvalidations2todb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderProducts",
                newName: "OrderProductId");

            migrationBuilder.AddColumn<int>(
                name: "OrderProductId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderProductId",
                table: "Product",
                column: "OrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_OrderProducts_OrderProductId",
                table: "Product",
                column: "OrderProductId",
                principalTable: "OrderProducts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_OrderProducts_OrderProductId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_OrderProductId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "OrderProductId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "OrderProductId",
                table: "OrderProducts",
                newName: "ProductId");
        }
    }
}
