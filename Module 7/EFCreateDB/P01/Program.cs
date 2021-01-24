namespace P01
{
    using P01.Data;
    using P01.Data.Models;
    using System;

  public  class Program
    {
       public static void Main()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            dbContext.Countries.Add(new Country() { Name = "Bulgaria" });
            dbContext.SaveChanges();
        }
    }
}
