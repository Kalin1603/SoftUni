using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHUSHKA.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Orders = new List<Order>();
        }
        public string FullName { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
