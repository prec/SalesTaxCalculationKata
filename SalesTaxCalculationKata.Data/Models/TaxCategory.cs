using System.ComponentModel.DataAnnotations.Schema;

namespace SalesTaxCalculationKata.Data.Models
{
    [Table("TaxCategories")]
    public class TaxCategory
    {
        public int TaxCategoryId { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int TaxId { get; set; }
        public virtual Tax Tax { get; set; }
    }
}