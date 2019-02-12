using System.Collections.Generic;

namespace SalesTaxCalculationKata.Core.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public List<OrderItemModel> OrderItems { get; set; } = new List<OrderItemModel>();
        public decimal SalesTaxTotal { get; set; }
        public decimal GrandTotal { get; set; }
        public bool IsComplete { get; set; }
    }
}