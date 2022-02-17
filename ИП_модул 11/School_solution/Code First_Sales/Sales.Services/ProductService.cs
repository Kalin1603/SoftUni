namespace Code_First_Sales.Sales.Services
{
    using Code_First_Sales.Data;
    using Code_First_Sales.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductService
    {
        private readonly SalesContext salesContext;

        public ProductService()
        {
            this.salesContext = new SalesContext();
        }

        public string AddProduct(string name)
        {
            Product product = GetProductByName(name);

            if (product == null)
            {
                this.salesContext.Products.Add(new Product() { Name = name });
                salesContext.SaveChanges();
                return $"Product: {name} is added!";
            }

            else
            {
                return $"Product: {name} already exists!";
            }
        }

        public string RemoveProduct(int id, string removedName)
        {
            Product product = GetProductById(id);

            if (product != null)
            {
                product.Name = removedName;
                salesContext.Products.Remove(product);
                salesContext.SaveChanges();
                return $"Product with id: {id} and Name: {removedName} is removed!";
            }

            else
            {
                return $"Product with id: {id} isn't found!";
            }
        }

        public string EditProductNameById(int id, string newName)
        {
            Product product = GetProductById(id);
            if (product != null)
            {
                product.Name = newName;
                salesContext.Products.Update(product);
                salesContext.SaveChanges();
                return $"Product with id: {id} has new Name: {newName}";
            }
            else
            {
                return $"Product with id: {id} isn't found!";
            }
        }

        public string ProductsInfo()
        {
            StringBuilder sb = new StringBuilder();

            List<Product> products = salesContext.Products.ToList();

            sb.AppendLine(">> Products list");
            sb.AppendLine(new string('-', 30));
            sb.AppendLine($"{"Id",3} | {"Name",10}");
            sb.AppendLine(new string('-', 30));

            foreach (var p in products)
            {
                sb.AppendLine($"{p.ProductId,3} | {p.Name,10}");
            }

            sb.AppendLine(new string('-', 30));
            return sb.ToString().TrimEnd();
        }

        public Product GetProductByName(string name)
        {
            return this.salesContext.Products.FirstOrDefault(p => p.Name == name);
        }

        public Product GetProductById(int id)
        {
            return this.salesContext.Products.FirstOrDefault(p => p.ProductId == id);
        }
    }
}
