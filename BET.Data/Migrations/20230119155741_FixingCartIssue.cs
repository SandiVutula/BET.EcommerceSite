using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BET.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixingCartIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Orders_OrderId",
                table: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.RenameTable(
                name: "ShoppingCart",
                newName: "Carts");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_OrderId",
                table: "Carts",
                newName: "IX_Carts_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Orders_OrderId",
                table: "Carts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Orders_OrderId",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "ShoppingCart");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_OrderId",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Orders_OrderId",
                table: "ShoppingCart",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
