using System.ComponentModel.DataAnnotations.Schema;

namespace SalesTaxCalculationKata.Data.Models
{
    [Table("Products")]
    public class Product
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public bool IsImported { get; set; }
    }
}