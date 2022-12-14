using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SevenEleven.Inventory.Mvc.Migrations
{
    public partial class _20220826InventoryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StockAvailable",
                table: "Stocks",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockAvailable",
                table: "Stocks");
        }
    }
}
