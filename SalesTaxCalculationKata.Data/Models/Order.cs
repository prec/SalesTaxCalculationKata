using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesTaxCalculationKata.Data.Models
{
    [Table("Orders")]
    public class Order
    {
        public int OrderId { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public decimal SalesTaxTotal { get; set; }
        public decimal GrandTotal { get; set; }
    }
}