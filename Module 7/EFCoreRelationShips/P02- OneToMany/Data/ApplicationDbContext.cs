namespace P02__OneToMany.Data
{
    using Microsoft.EntityFrameworkCore;
    using P02__OneToMany.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Model> Models { get; set; }

        public DbSet<Manufacturer> Manifacturers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=manufacturersDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>().HasOne(mo => mo.Manufacturer).WithMany(ma => ma.Models).HasForeignKey(ma => ma.ManufacturerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
