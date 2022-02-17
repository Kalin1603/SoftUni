namespace Code_First_Sales.Sales.Services
{
    using Code_First_Sales.Data;
    using Code_First_Sales.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StoreService
    {
        private readonly SalesContext salesContext;

        public StoreService()
        {
            this.salesContext = new SalesContext();
        }

        public string AddStore(string name)
        {
            Store store = GetStoreByName(name);

            if (store == null)
            {
                this.salesContext.Stores.Add(new Store() { Name = name });
                salesContext.SaveChanges();
                return $"Store: {name} is added!";
            }

            else
            {
                return $"Store: {name} already exists!";
            }
        }

        public string RemoveStore(int id, string removedName)
        {
            Store store = GetStoreById(id);

            if (store != null)
            {
                store.Name = removedName;
                salesContext.Stores.Remove(store);
                salesContext.SaveChanges();
                return $"Store with id: {id} and Name: {removedName} is removed!";
            }

            else
            {
                return $"Store with id: {id} isn't found!";
            }
        }

        public string EditStoreNameById(int id, string newName)
        {
            Store store = GetStoreById(id);
            if (store != null)
            {
                store.Name = newName;
                salesContext.Stores.Update(store);
                salesContext.SaveChanges();
                return $"Store with id: {id} has new Name: {newName}";
            }
            else
            {
                return $"Store with id: {id} isn't found!";
            }
        }

        public string StoreInfo()
        {
            StringBuilder sb = new StringBuilder();

            List<Store> stores = salesContext.Stores.ToList();

            sb.AppendLine(">> Stores list");
            sb.AppendLine(new string('-', 30));
            sb.AppendLine($"{"Id",3} | {"Name",10}");
            sb.AppendLine(new string('-', 30));

            foreach (var s in stores)
            {
                sb.AppendLine($"{s.StoreId,3} | {s.Name,10}");
            }

            sb.AppendLine(new string('-', 30));
            return sb.ToString().TrimEnd();
        }

        public Store GetStoreByName(string name)
        {
            return this.salesContext.Stores.FirstOrDefault(s => s.Name == name);
        }

        public Store GetStoreById(int id)
        {
            return this.salesContext.Stores.FirstOrDefault(s => s.StoreId == id);
        }
    }
}
