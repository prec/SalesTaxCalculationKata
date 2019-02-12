using System.Collections.Generic;
using NUnit.Framework;
using SalesTaxCalculationKata.Core.Models;

namespace SalesTaxCalculationKata.Core.Tests
{
    [TestFixture]
    public class TransactionRegisterTests
    {
        private TestDataProvider _dataProvider;

        [SetUp]
        public void SetupTests()
        {
            _dataProvider = new TestDataProvider();
        }

        [Test]
        public void AddItem_NormalProductWithCategory_NoException()
        {
            var register = SetupStandardRegister();

            var product = _dataProvider.CreateSalesExemptProduct();

            Assert.That(() => register.AddItem(product), Throws.Nothing);
        }

        [Test]
        public void FinishSale_NormalProduct_Calculate()
        {
            var register = SetupStandardRegister();

            var product = _dataProvider.CreateProduct();

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

            var product = _dataProvider.CreateSalesExemptProduct();

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

            var product = _dataProvider.CreateImportProduct();

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

            var product = _dataProvider.CreateSalesExemptImportProduct();

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
