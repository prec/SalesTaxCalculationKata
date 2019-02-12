using System.ComponentModel.DataAnnotations.Schema;

namespace SalesTaxCalculationKata.Data.Models
{
    [Table("TaxCategories")]
    public class TaxCategory
    {
        public int TaxCategoryId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TaxId { get; set; }
        public Tax Tax { get; set; }
    }
}