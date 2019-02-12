using System.Collections.Generic;
using SalesTaxCalculationKata.Core.Models;

namespace SalesTaxCalculationKata.Core.Tests
{
    public class TestDataProvider
    {
        public ProductModel CreateProduct()
        {
            var product = new ProductModel
            {
                Description = "Music CD",
                Price = 14.99m,
                ProductCategories = new List<CategoryModel>
                {
                    new CategoryModel
                    {
                        Description = "Music",
                        CategoryId = 5
                    }
                },
                ProductId = 2
            };

            return product;
        }

        public ProductModel CreateImportProduct()
        {
            var product = new ProductModel
            {
                Description = "Imported Bottle of Perfume",
                Price = 47.50m,
                ProductCategories = new List<CategoryModel>
                {
                    new CategoryModel
                    {
                        Description = "Cosmetics",
                        CategoryId = 4
                    },
                    new CategoryModel
                    {
                        Description = "Import",
                        CategoryId = 6
                    }
                }
            };

            return product;
        }

        public ProductModel CreateSalesExemptImportProduct()
        {
            var product = new ProductModel
            {
                Description = "Imported Box of Chocolates",
                Price = 10m,
                ProductCategories = new List<CategoryModel>
                {
                    new CategoryModel
                    {
                        Description = "Food",
                        CategoryId = 2
                    },
                    new CategoryModel
                    {
                        Description = "Import",
                        CategoryId = 6
                    }
                }
            };

            return product;
        }

        public ProductModel CreateSalesExemptProduct()
        {
            var product = new ProductModel
            {
                Description = "Book",
                Price = 12.49m,
                ProductCategories = new List<CategoryModel>
                {
                    new CategoryModel
                    {
                        Description = "Books",
                        CategoryId = 1
                    }
                },
                ProductId = 1
            };

            return product;
        }
    }
}