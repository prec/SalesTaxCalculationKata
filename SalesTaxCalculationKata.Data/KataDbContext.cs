using Microsoft.EntityFrameworkCore;
using SalesTaxCalculationKata.Data.Models;

namespace SalesTaxCalculationKata.Data
{
    public class KataDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<TaxCategory> TaxCategories { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SalesTaxCalculationKata;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetupProductCategoryJoinTable(modelBuilder);
            SeedDatabase(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SeedDatabase(ModelBuilder modelBuilder)
        {
            var dataProvider = new SeedDataProvider();

            modelBuilder.Entity<ProductCategory>().HasData(dataProvider.GetProductCategories());
            modelBuilder.Entity<Category>().HasData(dataProvider.GetCategories());
            modelBuilder.Entity<Tax>().HasData(dataProvider.GetTaxes());
            modelBuilder.Entity<Product>().HasData(dataProvider.GetProductData());
            modelBuilder.Entity<TaxCategory>().HasData(dataProvider.GetTaxCategories());
        }

        private static void SetupProductCategoryJoinTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(ppc => new {ppc.ProductId, ppc.CategoryId});
            modelBuilder.Entity<ProductCategory>()
                .HasOne(ppc => ppc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(ppc => ppc.ProductId);
            modelBuilder.Entity<ProductCategory>()
                .HasOne(ppc => ppc.Category)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(ppc => ppc.CategoryId);
        }
    }
}