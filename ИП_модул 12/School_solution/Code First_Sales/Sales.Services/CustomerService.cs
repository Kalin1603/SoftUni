namespace Code_First_Sales.Sales.Services
{
    using Code_First_Sales.Data;
    using Code_First_Sales.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CustomerService
    {
        private readonly SalesContext salesContext;

        public CustomerService()
        {
            this.salesContext = new SalesContext();
        }

        public string AddCustomer(string name)
        {
            Customer customer = GetCustomerByName(name);

            if (customer == null)
            {
                this.salesContext.Customers.Add(new Customer() { Name = name });
                salesContext.SaveChanges();
                return $"Customer: {name} is added!";
            }

            else
            {
                return $"Customer: {name} already exists!";
            }
        }

        public string RemoveCustomer(int id, string removedName)
        {
            Customer customer = GetCustomerById(id);

            if (customer != null)
            {
                customer.Name = removedName;
                salesContext.Customers.Remove(customer);
                salesContext.SaveChanges();
                return $"Customer with id: {id} and Name: {removedName} is removed!";
            }

            else
            {
                return $"Customer with id: {id} isn't found!";
            }
        }

        public string EditCustomerNameById(int id, string newName)
        {
            Customer customer = GetCustomerById(id);
            if (customer != null)
            {
                customer.Name = newName;
                salesContext.Customers.Update(customer);
                salesContext.SaveChanges();
                return $"Customer with id: {id} has new Name: {newName}";
            }
            else
            {
                return $"Customer with id: {id} isn't found!";
            }
        }

        public string CustomersInfo()
        {
            StringBuilder sb = new StringBuilder();

            List<Customer> customers = salesContext.Customers.ToList();

            sb.AppendLine(">> Customers list");
            sb.AppendLine(new string('-', 30));
            sb.AppendLine($"{"Id",3} | {"Name",10}");
            sb.AppendLine(new string('-', 30));

            foreach (var c in customers)
            {
                sb.AppendLine($"{c.CustomerId,3} | {c.Name,10}");
            }

            sb.AppendLine(new string('-', 30));
            return sb.ToString().TrimEnd();
        }

        public Customer GetCustomerByName(string name)
        {
            return this.salesContext.Customers.FirstOrDefault(c => c.Name == name);
        }

        public Customer GetCustomerById(int id)
        {
            return this.salesContext.Customers.FirstOrDefault(c => c.CustomerId == id);
        }
    }
}
