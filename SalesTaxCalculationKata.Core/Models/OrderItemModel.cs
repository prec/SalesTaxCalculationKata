namespace SalesTaxCalculationKata.Core.Models
{
    public class OrderItemModel
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public decimal SalesTax { get; set; }
    }
}