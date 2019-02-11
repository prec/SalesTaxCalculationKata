using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesTaxCalculationKata.Data.Migrations
{
    public partial class AddInitialSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "ProductCategoryId", "Description" },
                values: new object[,]
                {
                    { 1, "Books" },
                    { 2, "Food" },
                    { 3, "Medical Products" },
                    { 4, "Cosmetics" },
                    { 5, "Music" }
                });

            migrationBuilder.InsertData(
                table: "Taxes",
                columns: new[] { "TaxId", "Description", "Rate" },
                values: new object[,]
                {
                    { 1, "Sales", 0.1m },
                    { 2, "Import", 0.05m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "IsImported", "Price", "ProductCategoryId" },
                values: new object[,]
                {
                    { 1, "Book", false, 12.49m, 1 },
                    { 3, "Chocolate Bar", false, 0.85m, 2 },
                    { 4, "Imported Box of Chocolates", true, 10m, 2 },
                    { 9, "Imported Chocolates", true, 11.25m, 2 },
                    { 8, "Packet of Headache Pills", false, 9.75m, 3 },
                    { 5, "Imported Bottle of Fancy Perfume", true, 47.50m, 4 },
                    { 6, "Imported Bottle of Perfume", true, 27.99m, 4 },
                    { 7, "Bottle of Perfume", false, 18.99m, 4 },
                    { 2, "Music CD", false, 14.99m, 5 }
                });

            migrationBuilder.InsertData(
                table: "TaxExemptions",
                columns: new[] { "TaxExemptionId", "ProductCategoryId", "TaxId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TaxExemptions",
                keyColumn: "TaxExemptionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaxExemptions",
                keyColumn: "TaxExemptionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaxExemptions",
                keyColumn: "TaxExemptionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 1);
        }
    }
}
