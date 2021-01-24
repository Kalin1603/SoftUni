using P02_StudentsServices;
using System;
using System.Text;

namespace P02_StudentsConsoleApp
{
    public class Engine
    {
        private CountryService countryService;

        public Engine()
        {
            this.countryService = new CountryService();
        }

        public void Run()
        {
            while (true)
            {
                PrintMenu();

                string cmd = Console.ReadLine();
                string result = string.Empty;
                switch (cmd)
                {
                    case "1":
                        result = AddCountry();
                        break;
                    case "2":
                        result = countryService.GetAllCountries();
                        break;
                    case "3":
                        result = EditCountryName();
                        break;
                    case "4":
                        result = RemoveCountry();
                        break;
                    default:
                        result = "Not supported command!";
                        break;
                }

                if (!string.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine(result);
                }
            }
        }

        private void PrintMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1: Add Country");
            sb.AppendLine("2: Country List");
            sb.AppendLine("3: Change country name");
            sb.AppendLine("4: Remove country");
            sb.Append("Enter command");
            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private string AddCountry()
        {
            Console.Write("Enter country name: ");
            string name = Console.ReadLine();
            return countryService.AddCountry(name);
        }

        private string EditCountryName()
        {
            Console.Write("Enter country id: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter country new name: ");
            string newName = Console.ReadLine();
            return countryService.EditCountryNameById(id,newName);
        }

        public string RemoveCountry()
        {
            Console.Write("Enter country id: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter country name: ");
            string removedName = Console.ReadLine();
            return countryService.RemoveCountry(id,removedName);
        }
    }
}
