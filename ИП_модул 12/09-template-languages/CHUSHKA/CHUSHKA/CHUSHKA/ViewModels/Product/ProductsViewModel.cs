using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHUSHKA.ViewModels.Product
{
    public class ProductsViewModel
    {
        public int Count { get; set; }

        public int Rows => this.Count % 5;

        public IEnumerable<DisplayProductViewModel> Products { get; set; }
    }
}
