using System.Collections.Generic;
using NUnit.Framework;
using SalesTaxCalculationKata.Core;
using SalesTaxCalculationKata.Core.Models;

namespace SalesTaxCalcuationKata.Core.Tests
{
    [TestFixture]
    public class TransactionRegisterTests
    {
        [Test]
        public void AddItem_NormalProductWithCategory_NoException()
        {
            var register = SetupStandardRegister();

            var product = CreateSalesExemptProduct();

            Assert.That(() => register.AddItem(product), Throws.Nothing);
        }

        private static ProductModel CreateSalesExemptProduct()
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

        private static ProductModel CreateProduct()
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

        public static ProductModel CreateImportProduct()
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

        public static ProductModel CreateSalesExemptImportProduct()
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

        [Test]
        public void FinishSale_NormalProduct_Calculate()
        {
            var register = SetupStandardRegister();

            var product = CreateProduct();

            register.AddItem(product);

            var order = register.CompleteSale();

            decimal expected = 16.49m;
            decimal actual = order.GrandTotal;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FinishSale_SalesExemptProduct_Calculate()
        {
            var register = SetupStandardRegister();

            var product = CreateSalesExemptProduct();

            register.AddItem(product);

            var order = register.CompleteSale();

            decimal expected = 12.49m;
            decimal actual = order.GrandTotal;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FinishSale_ImportProduct_Calculate()
        {
            var register = SetupStandardRegister();

            var product = CreateImportProduct();

            register.AddItem(product);

            var order = register.CompleteSale();

            decimal expected = 54.65m;
            decimal actual = order.GrandTotal;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FinishSale_ImportSalesExemptProduct_Calculate()
        {
            var register = SetupStandardRegister();

            var product = CreateSalesExemptImportProduct();

            register.AddItem(product);

            var order = register.CompleteSale();

            decimal expected = 10.50m;
            decimal actual = order.GrandTotal;

            Assert.AreEqual(expected, actual);
        }

        private static TransactionRegister SetupStandardRegister()
        {
            var taxes = new List<TaxModel>
            {
                new TaxModel
                {
                    Description = "Sales",
                    Rate = 0.1m,
                    TaxId = 1
                },
                new TaxModel
                {
                    Description = "Import",
                    Rate = 0.05m,
                    TaxId = 2
                }
            };

            var taxCategories = new List<TaxCategoryModel>
            {
                new TaxCategoryModel
                {
                    Category = new CategoryModel
                    {
                        Description = "Cosmetics",
                        CategoryId = 4
                    },
                    Tax = new TaxModel
                    {
                        Description = "Sales",
                        Rate = 0.1m,
                        TaxId = 1
                    }
                },
                new TaxCategoryModel
                {
                    Category = new CategoryModel
                    {
                        Description = "Music",
                        CategoryId = 5
                    },
                    Tax = new TaxModel
                    {
                        Description = "Sales",
                        Rate = 0.1m,
                        TaxId = 1
                    }
                },
                new TaxCategoryModel
                {
                    Category = new CategoryModel
                    {
                        Description = "Import",
                        CategoryId = 6
                    },
                    Tax = new TaxModel
                    {
                        Description = "Import",
                        Rate = 0.05m,
                        TaxId = 2
                    }
                }
            };

            return new TransactionRegister(taxes, taxCategories);
        }
    }
}
