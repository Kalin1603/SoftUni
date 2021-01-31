namespace P01__OneToOne
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public DbSet<Passport> Passports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=personDb;Trusted_Connection=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passport>().HasOne(pa => pa.Person).WithOne(pe => pe.Passport).HasForeignKey<Person>(pe=>pe.PassportId);
        }
    }
}
