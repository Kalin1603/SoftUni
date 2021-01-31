namespace P02_StudentsConsoleApp
{
    using P02_StudentsAppData;
    using P02_StudentsServices;
    using System;
    using System.Text;

    public class Engine
    {
        private static ApplicationDbContext dbContext = new ApplicationDbContext();
        private static CountryService countryService = new CountryService(dbContext);
        private static TownsService townsService = new TownsService(dbContext,countryService);
        private static AddressesService addressesService = new AddressesService(dbContext, townsService,countryService);
        private static StudentsService studentsService = new StudentsService(dbContext,addressesService);


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
                    case "5":
                        result = AddTown();
                        break;
                    case "6":
                        result = townsService.GetAllTowns();
                        break;
                    case "7":
                        result = AddStudent();
                        break;
                    case "8":
                        result = studentsService.GetAllStudents();
                        break;
                    case "9":
                        result = GetStudentInfoById();
                        break;
                    default:
                        result = ">> Not supported command!";
                        break;
                }

                if (!string.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine(result);
                }
            }
        }

        private string GetStudentInfoById()
        {
            Console.Write("<< Enter student id: ");
            int id = int.Parse(Console.ReadLine());
            return studentsService.GetStudentInfoById(id);
        }

        private void PrintMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1: Add Country");
            sb.AppendLine("2: Country List");
            sb.AppendLine("3: Change country name");
            sb.AppendLine("4: Remove country");
            sb.AppendLine("5: Add town");
            sb.AppendLine("6: Towns List");
            sb.AppendLine("7: Add student");
            sb.AppendLine("8: Students List");
            sb.AppendLine("9: Get students info by id");
            sb.Append("<< Enter command: ");
            Console.Write(sb.ToString());
        }

        private string AddCountry()
        {
            Console.Write("<< Enter country name: ");
            string name = Console.ReadLine();
            return countryService.AddCountry(name);
        }

        private string AddTown()
        {
            Console.Write("<< Enter town name: ");
            string townName = Console.ReadLine();
            Console.Write("<< Enter country name: ");
            string countryName = Console.ReadLine();
            return townsService.AddTown(townName, countryName);
        }

        private string AddStudent()
        {
            Console.Write("<< Enter student first name: ");
            string firstName = Console.ReadLine();
            Console.Write("<< Enter student last name: ");
            string lastName = Console.ReadLine();
            Console.Write("<< Enter student age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("<< Enter student country: ");
            string country = Console.ReadLine();
            Console.Write("<< Enter student town: ");
            string town = Console.ReadLine();
            Console.Write("<< Enter student address: ");
            string address = Console.ReadLine();
            Console.Write("<< Enter student school id: ");
            int schoolId = int.Parse(Console.ReadLine());
            return studentsService.AddStudent(firstName, lastName, age, country, town, address, schoolId);
        }

        private string EditCountryName()
        {
            Console.Write("<< Enter country id: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("<< Enter country new name: ");
            string newName = Console.ReadLine();
            return countryService.EditCountryNameById(id,newName);
        }

        private string RemoveCountry()
        {
            Console.Write("<< Enter country id: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("<< Enter country name: ");
            string removedName = Console.ReadLine();
            return countryService.RemoveCountry(id,removedName);
        }
    }
}
