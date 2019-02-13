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
                    Price = 12.49m,
                    ProductId = 1
                },
                new Product
                {
                    Description = "Music CD",
                    Price = 14.99m,
                    ProductId = 2
                },
                new Product
                {
                    Description = "Chocolate Bar",
                    Price = 0.85m,
                    ProductId = 3
                },
                new Product
                {
                    Description = "Imported Box of Chocolates",
                    Price = 10m,
                    ProductId = 4
                },
                new Product
                {
                    Description = "Imported Bottle of Fancy Perfume",
                    Price = 47.50m,
                    ProductId = 5
                },
                new Product
                {
                    Description = "Imported Bottle of Perfume",
                    Price = 27.99m,
                    ProductId = 6
                },
                new Product
                {
                    Description = "Bottle of Perfume",
                    Price = 18.99m,
                    ProductId = 7
                },
                new Product
                {
                    Description = "Packet of Headache Pills",
                    Price = 9.75m,
                    ProductId = 8
                },
                new Product
                {
                    Description = "Imported Chocolates",
                    Price = 11.25m,
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
                    ProductId = 1,
                    CategoryId = 1,
                    ProductCategoryId = 1
                },
                new ProductCategory
                {
                    ProductId = 2,
                    CategoryId = 5,
                    ProductCategoryId = 2
                },
                new ProductCategory
                {
                    ProductId = 3,
                    CategoryId = 2,
                    ProductCategoryId = 3
                },
                new ProductCategory
                {
                    ProductId = 4,
                    CategoryId = 2,
                    ProductCategoryId = 4
                },
                new ProductCategory
                {
                    ProductId = 4,
                    CategoryId = 6,
                    ProductCategoryId = 5
                },
                new ProductCategory
                {
                    ProductId = 5,
                    CategoryId = 4,
                    ProductCategoryId = 6
                },
                new ProductCategory
                {
                    ProductId = 5,
                    CategoryId = 6,
                    ProductCategoryId = 7
                },
                new ProductCategory
                {
                    ProductId = 6,
                    CategoryId = 4,
                    ProductCategoryId = 8
                },
                new ProductCategory
                {
                    ProductId = 6,
                    CategoryId = 6,
                    ProductCategoryId = 9
                },
                new ProductCategory
                {
                    ProductId = 7,
                    CategoryId = 4,
                    ProductCategoryId = 10
                },
                new ProductCategory
                {
                    ProductId = 8,
                    CategoryId = 3,
                    ProductCategoryId = 11
                },
                new ProductCategory
                {
                    ProductId = 9,
                    CategoryId = 2,
                    ProductCategoryId = 12
                },
                new ProductCategory
                {
                    ProductId = 9,
                    CategoryId = 6,
                    ProductCategoryId = 13
                }
            };
        }

        public List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    Description = "Books",
                    CategoryId = 1
                },
                new Category
                {
                    Description = "Food",
                    CategoryId = 2
                },
                new Category
                {
                    Description = "Medical Products",
                    CategoryId = 3
                },
                new Category
                {
                    Description = "Cosmetics",
                    CategoryId = 4
                },
                new Category
                {
                    Description = "Music",
                    CategoryId = 5
                },
                new Category
                {
                    Description = "Import",
                    CategoryId = 6
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

        public List<TaxCategory> GetTaxCategories()
        {
            return new List<TaxCategory>
            {
                new TaxCategory
                {
                    CategoryId = 4,
                    TaxId = 1,
                    TaxCategoryId = 1
                },
                new TaxCategory
                {
                    CategoryId = 5,
                    TaxId = 1,
                    TaxCategoryId = 2
                },
                new TaxCategory
                {
                    CategoryId = 6,
                    TaxId = 2,
                    TaxCategoryId = 3
                }
            };
        }
    }
}
