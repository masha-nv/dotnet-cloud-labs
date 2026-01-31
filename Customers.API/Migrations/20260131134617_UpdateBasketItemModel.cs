using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customers.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBasketItemModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BasketId",
                table: "Items",
                newName: "CustomerBasket");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerBasket",
                table: "Items",
                newName: "BasketId");
        }
    }
}
