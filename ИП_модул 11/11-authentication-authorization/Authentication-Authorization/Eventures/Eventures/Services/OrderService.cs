using Eventures.Data;
using Eventures.Domain;
using Eventures.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext context;
        private readonly IEventService eventService;

        public OrderService(ApplicationDbContext context,IEventService eventService)
        {
            this.context = context;
            this.eventService = eventService;
        }

        public void OrderTickets(int eventId, string userId, int tickets)
        {
            var @event = this.eventService.GetEventById(eventId);

            var order = new Order
            {
                OrderedOn = DateTime.UtcNow,
                EventId = @event.Id,
                CustomerId = userId,
                TicketsCount = tickets
            };

            @event.TotalTickets -= tickets;

            this.context.Orders.Add(order);
            this.context.SaveChanges();
        }
        public Order[] GetAllOrders()
        {
            var orders = this.context
                   .Orders
                   .Include(o => o.Event)
                   .Include(o => o.Customer)
                   .ToArray();

            return orders;
        }
        public Order[] GetMyOrders(string userId)
        {
            var orders = this.context
                .Orders
                .Where(o => o.CustomerId == userId)
                .Include(o => o.Event)
                .ToArray();

            return orders;
        }
    }
}
