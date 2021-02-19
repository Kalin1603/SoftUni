namespace RealEstates.ConsoleApp
{
    using RealEstates.Data;
    using RealEstates.Services;
    using System;

    public class Program
    {
        public static void Main()
        {
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            PropertiesService propertiesService = new PropertiesService(applicationDbContext);
            Engine engine = new Engine(propertiesService);
            engine.Run();
        }
    }
}
