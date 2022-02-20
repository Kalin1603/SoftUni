using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHUSHKA.ViewModels.Order
{
    public class AllOrdersViewModel
    {
        public IEnumerable<OrderViewModel> AllOrders { get; set; }
    }
}
