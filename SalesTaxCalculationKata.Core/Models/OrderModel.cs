using System.Collections.Generic;

namespace SalesTaxCalculationKata.Core.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }
        public decimal SalesTaxTotal { get; set; }
        public decimal GrandTotal { get; set; }
    }
}