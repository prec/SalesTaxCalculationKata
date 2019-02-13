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
                Categories = new List<CategoryModel>
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
                Categories = new List<CategoryModel>
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
                Categories = new List<CategoryModel>
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
                Categories = new List<CategoryModel>
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

        public List<ProductModel> CreateScenarioThreeProducts()
        {
            var productList = new List<ProductModel>
            {
                new ProductModel
                {
                    Description = "Imported Bottle of Perfume",
                    Price = 27.99m,
                    Categories = new List<CategoryModel>
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
                    },
                    ProductId = 1
                },
                new ProductModel
                {
                    Description = "Bottle of Perfume",
                    Price = 18.99m,
                    Categories = new List<CategoryModel>
                    {
                        new CategoryModel
                        {
                            Description = "Cosmetics",
                            CategoryId = 4
                        }
                    },
                    ProductId = 1
                },
                new ProductModel
                {
                    Description = "Packet of Headache Pills",
                    Price = 9.75m,
                    Categories = new List<CategoryModel>
                    {
                        new CategoryModel
                        {
                            Description = "Medical Supplies",
                            CategoryId = 3
                        }
                    },
                    ProductId = 1
                },
                new ProductModel
                {
                    Description = "Imported Box of Chocolates",
                    Price = 11.25m,
                    Categories = new List<CategoryModel>
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
                    },
                    ProductId = 1
                },
                new ProductModel
                {
                    Description = "Imported Box of Chocolates",
                    Price = 11.25m,
                    Categories = new List<CategoryModel>
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
                    },
                    ProductId = 1
                }
            };

            return productList;
        }
    }
}