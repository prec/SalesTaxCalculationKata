using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesTaxCalculationKata.Data.Models
{
    [Table("Products")]
    public class Product
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}