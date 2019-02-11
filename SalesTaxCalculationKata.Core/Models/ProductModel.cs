namespace SalesTaxCalculationKata.Core.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ProductCategoryId { get; set; }
        public bool IsImported { get; set; }
    }
}