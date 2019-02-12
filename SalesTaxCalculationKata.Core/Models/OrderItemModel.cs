namespace SalesTaxCalculationKata.Core.Models
{
    public class OrderItemModel
    {
        public int OrderItemId { get; set; }
        public ProductModel Product { get; set; }
        public decimal SalesTax { get; set; }
    }
}