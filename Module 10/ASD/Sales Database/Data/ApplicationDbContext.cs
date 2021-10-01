namespace Sales_Database.Data
{
    using Microsoft.EntityFrameworkCore;
    using Sales_Database.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ApplicationDbContext : DbContext
    {
        private const string ConnectionString = "Server=.;Database=SalesDb;Trusted_Connection=True;";

        protected ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }

        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>(
                entity =>
                {
                    entity.HasKey(x => new { x.ProductId, x.CustomerId, x.StoreId });
                }
            );
        }
    }
}
