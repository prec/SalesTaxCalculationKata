using System.ComponentModel.DataAnnotations.Schema;

namespace SalesTaxCalculationKata.Data.Models
{
    [Table("TaxExemptions")]
    public class TaxExemption
    {
        public int TaxExemptionId { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int TaxId { get; set; }
        public Tax Tax { get; set; }
    }
}