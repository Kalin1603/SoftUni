using Microsoft.EntityFrameworkCore;
using TeisterMask.Data.Models;

namespace TeisterMask.Data
{
    public class TeisterMaskDbContext : DbContext
    {
        public TeisterMaskDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-7F6IE13\\SQLEXPRESS;Database=TeiserMaskDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public virtual DbSet<Task> Tasks { get; set; }
    }
}
