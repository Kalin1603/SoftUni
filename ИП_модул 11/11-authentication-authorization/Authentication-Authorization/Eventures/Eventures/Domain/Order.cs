using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Domain
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderedOn { get; set; } = DateTime.UtcNow;

        public int EventId { get; set; }
        public Event Event { get; set; }

        public string CustomerId { get; set; }
        public User Customer { get; set; }

        public int TicketsCount { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
