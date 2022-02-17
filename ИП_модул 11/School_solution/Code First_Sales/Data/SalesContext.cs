namespace Code_First_Sales.Data
{
    using Code_First_Sales.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SalesContext : DbContext
    {
        private const string ConnectionString =
            "Server=DESKTOP-7F6IE13\\SQLEXPRESS;Database=SalesDb;Trusted_Connection=True;";

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>(entity =>
            {
                entity.HasIndex(x => x.ProductId).IsUnique(true);
            });

            builder.Entity<Customer>(entity =>
            {
                entity.HasIndex(x => x.CustomerId).IsUnique(true);
            });

            builder.Entity<Store>(entity =>
            {
                entity.HasIndex(x => x.StoreId).IsUnique(true);
            });

            builder.Entity<Sale>(entity =>
            {
                entity.HasIndex(x => x.SaleId).IsUnique(true);
            });
        }
    }
}
