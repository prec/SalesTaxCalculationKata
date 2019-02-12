using System;
using System.Collections.Generic;
using System.Linq;
using SalesTaxCalculationKata.Core.Models;

namespace SalesTaxCalculationKata.Core
{
    public class TransactionRegister
    {
        private readonly List<TaxCategoryModel> _taxCategories;
        private readonly List<TaxModel> _taxes;

        private List<OrderItemModel> _currentOrder = new List<OrderItemModel>();

        public TransactionRegister(List<TaxModel> taxes, List<TaxCategoryModel> taxCategories)
        {
            _taxes = taxes;
            _taxCategories = taxCategories;
        }

        public void AddItem(ProductModel product)
        {
            var totalTax = CalculateTax(product);

            var orderItem = new OrderItemModel
            {
                Product = product,
                SalesTax = totalTax
            };

            _currentOrder.Add(orderItem);
        }

        public OrderModel CompleteSale()
        {
            var salesTaxTotal = _currentOrder.Sum(oi => oi.SalesTax);
            var preTaxTotal = _currentOrder.Sum(oi => oi.Product.Price);

            var order = new OrderModel
            {
                OrderItems = _currentOrder,
                SalesTaxTotal = salesTaxTotal,
                GrandTotal = salesTaxTotal + preTaxTotal
            };

            _currentOrder = new List<OrderItemModel>();

            return order;
        }

        private decimal CalculateTax(ProductModel product)
        {
            var applicableTaxes = from t in _taxes
                join tc in _taxCategories on t.TaxId equals tc.Tax.TaxId
                join pc in product.Categories on tc.Category.CategoryId equals pc.CategoryId
                select t;

            var totalTax = applicableTaxes.Sum(tax => product.Price * tax.Rate);
            return RoundToNearestNickel(totalTax);
        }

        private static decimal RoundToNearestNickel(decimal number)
        {
            return Math.Round(number*20, MidpointRounding.AwayFromZero)/20;
        }
    }
}