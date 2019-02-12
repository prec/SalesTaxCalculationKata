namespace SalesTaxCalculationKata.Core.Models
{
    public class TaxCategoryModel
    {
        public int TaxCategoryId { get; set; }
        public CategoryModel Category { get; set; }
        public TaxModel Tax { get; set; }
    }
}