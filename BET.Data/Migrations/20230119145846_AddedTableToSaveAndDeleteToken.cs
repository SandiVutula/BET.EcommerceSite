using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BET.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTableToSaveAndDeleteToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderItem",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ShoppingCart",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_OrderId",
                table: "ShoppingCart",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Orders_OrderId",
                table: "ShoppingCart",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Orders_OrderId",
                table: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_OrderId",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ShoppingCart");

            migrationBuilder.AddColumn<string>(
                name: "OrderItem",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
