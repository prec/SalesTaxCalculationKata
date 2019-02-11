using Microsoft.EntityFrameworkCore;
using SalesTaxCalculationKata.Data.Models;

namespace SalesTaxCalculationKata.Data
{
    public class KataDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<TaxExemption> TaxExemptions { get; set; }
        public DbSet<Tax> Taxes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SalesTaxCalculationKata;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dataProvider = new SeedDataProvider();

            modelBuilder.Entity<ProductCategory>().HasData(dataProvider.GetProductCategories());
            modelBuilder.Entity<Tax>().HasData(dataProvider.GetTaxes());
            modelBuilder.Entity<Product>().HasData(dataProvider.GetProductData());
            modelBuilder.Entity<TaxExemption>().HasData(dataProvider.GetTaxExemptions());

            base.OnModelCreating(modelBuilder);
        }
    }
}