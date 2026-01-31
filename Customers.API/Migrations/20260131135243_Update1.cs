using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customers.API.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Baskets_CustomerBasketId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CustomerBasket",
                table: "Items");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerBasketId",
                table: "Items",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Baskets_CustomerBasketId",
                table: "Items",
                column: "CustomerBasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Baskets_CustomerBasketId",
                table: "Items");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerBasketId",
                table: "Items",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerBasket",
                table: "Items",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Baskets_CustomerBasketId",
                table: "Items",
                column: "CustomerBasketId",
                principalTable: "Baskets",
                principalColumn: "Id");
        }
    }
}
