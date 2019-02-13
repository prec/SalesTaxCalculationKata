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

            Assert.That(() => register.AddItem(product, new OrderModel()), Throws.Nothing);
        }

        [Test]
        public void AddItems_NormalProductsWithCategory_NoException()
        {
            var register = SetupStandardRegister();

            var products = new List<ProductModel>
            {
                _dataProvider.CreateProduct(),
                _dataProvider.CreateProduct()
            };

            Assert.That(() => register.AddItems(products, new OrderModel()), Throws.Nothing);
        }

        [Test]
        public void CompleteOrder_NormalProduct_Calculate()
        {
            var register = SetupStandardRegister();

            var product = _dataProvider.CreateProduct();
            var order = new OrderModel();

            order = register.AddItem(product, order);
            order = register.CompleteOrder(order);

            decimal expected = 16.49m;
            decimal actual = order.GrandTotal;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CompleteOrder_SalesExemptProduct_Calculate()
        {
            var register = SetupStandardRegister();

            var product = _dataProvider.CreateSalesExemptProduct();
            var order = new OrderModel();

            order = register.AddItem(product, order);
            order = register.CompleteOrder(order);

            decimal expected = 12.49m;
            decimal actual = order.GrandTotal;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CompleteOrder_ImportProduct_Calculate()
        {
            var register = SetupStandardRegister();

            var product = _dataProvider.CreateImportProduct();
            var order = new OrderModel();

            order = register.AddItem(product, order);
            order = register.CompleteOrder(order);

            decimal expected = 54.65m;
            decimal actual = order.GrandTotal;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CompleteOrder_ImportSalesExemptProduct_Calculate()
        {
            var register = SetupStandardRegister();

            var product = _dataProvider.CreateSalesExemptImportProduct();
            var order = new OrderModel();

            order = register.AddItem(product, order);
            order = register.CompleteOrder(order);

            decimal expected = 10.50m;
            decimal actual = order.GrandTotal;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CompleteOrder_ScenarioThree_Calculate()
        {
            var register = SetupStandardRegister();

            var products = _dataProvider.CreateScenarioThreeProducts();
            var order = new OrderModel();

            order = register.AddItems(products, order);
            order = register.CompleteOrder(order);

            decimal expected = 86.53m;
            decimal actual = order.GrandTotal;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CompleteOrder_NormalOrder_Completes()
        {
            var register = SetupStandardRegister();

            var product = _dataProvider.CreateProduct();
            var order = new OrderModel();

            order = register.AddItem(product, order);
            order = register.CompleteOrder(order);

            Assert.IsTrue(order.IsComplete);
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
                    CategoryId = 4,
                    TaxId = 1
                },
                new TaxCategoryModel
                {
                    CategoryId = 5,
                    TaxId = 1
                },
                new TaxCategoryModel
                {
                    CategoryId = 6,
                    TaxId = 2
                }
            };

            return new TransactionRegister(taxes, taxCategories);
        }
    }
}
