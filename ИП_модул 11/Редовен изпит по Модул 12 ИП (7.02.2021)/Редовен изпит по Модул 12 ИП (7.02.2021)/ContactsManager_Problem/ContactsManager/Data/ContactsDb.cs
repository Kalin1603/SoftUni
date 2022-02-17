using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ContactsDb : DbContext
    {
        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-7F6IE13\SQLEXPRESS;Database=ContactsDb;Integrated Security = true;");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
