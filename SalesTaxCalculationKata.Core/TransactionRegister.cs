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

        public TransactionRegister(List<TaxModel> taxes, List<TaxCategoryModel> taxCategories)
        {
            _taxes = taxes;
            _taxCategories = taxCategories;
        }

        public OrderModel AddItems(List<ProductModel> products, OrderModel order)
        {
            foreach (var p in products)
            {
                order = AddItem(p, order);
            }

            return order;
        }

        public OrderModel AddItem(ProductModel product, OrderModel order)
        {
            var totalTax = CalculateTax(product);

            var orderItem = new OrderItemModel
            {
                Product = product,
                SalesTax = totalTax
            };

            order.OrderItems.Add(orderItem);

            return order;
        }

        public OrderModel CompleteOrder(OrderModel order)
        {
            order.SalesTaxTotal = order.OrderItems.Sum(oi => oi.SalesTax);
            order.GrandTotal = order.OrderItems.Sum(oi => oi.Product.Price) + order.SalesTaxTotal;
            order.IsComplete = true;

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