using CHUSHKA.Data.Models;
using CHUSHKA.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHUSHKA.Services.Interface
{
     public interface IProductService
     {
        void CreateProduct(string name, decimal price, string description, ProductType type);
        List<Product> GetAllProducts();

        Product GetProductById(int id);

        void ProductOrder(int productId, string userId);

        void EditProduct(int productId, string name, decimal price, string description, ProductType type);

        void DeleteProduct(int productId);

        List<Order> GetAllOrders();

     }
} 
