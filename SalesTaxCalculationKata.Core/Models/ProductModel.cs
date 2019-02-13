using System.Collections.Generic;

namespace SalesTaxCalculationKata.Core.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<CategoryModel> Categories { get; set; }
    }
}