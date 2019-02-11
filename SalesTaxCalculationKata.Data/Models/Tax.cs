using System.ComponentModel.DataAnnotations.Schema;

namespace SalesTaxCalculationKata.Data.Models
{
    [Table("Taxes")]
    public class Tax
    {
        public int TaxId { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
    }
}