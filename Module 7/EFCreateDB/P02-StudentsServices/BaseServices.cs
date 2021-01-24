namespace P02_StudentsServices
{
    using P02_StudentsAppData;

    public abstract class BaseServices
    {
        internal ApplicationDbContext dbContext;

        public BaseServices()
        {
            dbContext = new ApplicationDbContext();
        }
    }
}
