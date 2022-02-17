using CHUSHKA.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHUSHKA.Data.Models
{
    public class Product
    {

        public Product()
        {
            this.Orders = new List<Order>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public ProductType Type { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<Order> Orders { get; set; }

    }
}
