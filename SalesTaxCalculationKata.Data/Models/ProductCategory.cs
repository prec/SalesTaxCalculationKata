﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SalesTaxCalculationKata.Data.Models
{
    [Table("ProductCategories")]
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}