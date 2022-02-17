using Eventures.Data;
using Eventures.Domain;
using Eventures.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext context;

        public EventService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void CreateEvent(string name, string place, DateTime start, DateTime end, int totalTickets, decimal pricePerTicket)
        {

            var @event = new Event
            {
                Name = name,
                Place = place,
                Start = start,
                End = end,
                TotalTickets = totalTickets,
                PricePerTicket = pricePerTicket
            };

            this.context.Events.Add(@event);
            this.context.SaveChanges();
            
        }
        public Event[] GetAllEvents()
        {
            var events = this.context
                .Events
                .Where(e => e.TotalTickets != 0)
                .ToArray();

            return events;
        }

        public Event GetEventById(int id)
        {
            var @event = this.context.Events.Find(id);

            return @event;
        }

        public int GetTotalTicketsByEvent(int id)
        {
            var @event = this.context
                .Events
                .FirstOrDefault(e => e.Id == id);

            return @event.TotalTickets;
        }

    }

}
