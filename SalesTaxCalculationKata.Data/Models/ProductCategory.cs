using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesTaxCalculationKata.Data.Models
{
    [Table("ProductCategories")]
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}