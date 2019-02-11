using SalesTaxCalculationKata.Data.Models;
using System.Collections.Generic;

namespace SalesTaxCalculationKata.Data
{
    public class SeedDataProvider
    {
        public List<Product> GetProductData()
        {
            return new List<Product>
            {
                new Product
                {
                    Description = "Book",
                    IsImported = false,
                    Price = 12.49m,
                    ProductCategoryId = 1,
                    ProductId = 1
                },
                new Product
                {
                    Description = "Music CD",
                    IsImported = false,
                    Price = 14.99m,
                    ProductCategoryId = 5,
                    ProductId = 2
                },
                new Product
                {
                    Description = "Chocolate Bar",
                    IsImported = false,
                    Price = 0.85m,
                    ProductCategoryId = 2,
                    ProductId = 3
                },
                new Product
                {
                    Description = "Imported Box of Chocolates",
                    IsImported = true,
                    Price = 10m,
                    ProductCategoryId = 2,
                    ProductId = 4
                },
                new Product
                {
                    Description = "Imported Bottle of Fancy Perfume",
                    IsImported = true,
                    Price = 47.50m,
                    ProductCategoryId = 4,
                    ProductId = 5
                },
                new Product
                {
                    Description = "Imported Bottle of Perfume",
                    IsImported = true,
                    Price = 27.99m,
                    ProductCategoryId = 4,
                    ProductId = 6
                },
                new Product
                {
                    Description = "Bottle of Perfume",
                    IsImported = false,
                    Price = 18.99m,
                    ProductCategoryId = 4,
                    ProductId = 7
                },
                new Product
                {
                    Description = "Packet of Headache Pills",
                    IsImported = false,
                    Price = 9.75m,
                    ProductCategoryId = 3,
                    ProductId = 8
                },
                new Product
                {
                    Description = "Imported Chocolates",
                    IsImported = true,
                    Price = 11.25m,
                    ProductCategoryId = 2,
                    ProductId = 9
                }
            };
        }

        public List<ProductCategory> GetProductCategories()
        {
            return new List<ProductCategory>
            {
                new ProductCategory
                {
                    Description = "Books",
                    ProductCategoryId = 1
                },
                new ProductCategory
                {
                    Description = "Food",
                    ProductCategoryId = 2
                },
                new ProductCategory
                {
                    Description = "Medical Products",
                    ProductCategoryId = 3
                },
                new ProductCategory
                {
                    Description = "Cosmetics",
                    ProductCategoryId = 4
                },
                new ProductCategory
                {
                    Description = "Music",
                    ProductCategoryId = 5
                }
            };
        }

        public List<Tax> GetTaxes()
        {
            return new List<Tax>
            {
                new Tax
                {
                    Description = "Sales",
                    Rate = 0.1m,
                    TaxId = 1
                },
                new Tax
                {
                    Description = "Import",
                    Rate = 0.05m,
                    TaxId = 2
                }
            };
        }

        public List<TaxExemption> GetTaxExemptions()
        {
            return new List<TaxExemption>
            {
                new TaxExemption
                {
                    ProductCategoryId = 1,
                    TaxId = 1,
                    TaxExemptionId = 1
                },
                new TaxExemption
                {
                    ProductCategoryId = 2,
                    TaxId = 1,
                    TaxExemptionId = 2
                },
                new TaxExemption
                {
                    ProductCategoryId = 3,
                    TaxId = 1,
                    TaxExemptionId = 3
                }
            };
        }
    }
}
