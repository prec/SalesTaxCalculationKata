using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesTaxCalculationKata.Data.Migrations
{
    public partial class StoreSalesTaxWithOrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SalesTax",
                table: "OrderItems",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesTax",
                table: "OrderItems");
        }
    }
}
