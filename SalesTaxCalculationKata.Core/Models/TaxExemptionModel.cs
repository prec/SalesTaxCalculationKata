namespace SalesTaxCalculationKata.Core.Models
{
    public class TaxExemptionModel
    {
        public int TaxExemptionId { get; set; }
        public int ProductCategoryId { get; set; }
        public int TaxId { get; set; }
    }
}