using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.ViewModels.Orders
{
    public class CreateOrderViewModel
    {
        public int EventId { get; set; }

        public string CustomerName { get; set; }

        [Required]
        [Range(1, 1000)]
        [Display(Name = "Tickets")]
        public int Tickets { get; set; }
    }
}
