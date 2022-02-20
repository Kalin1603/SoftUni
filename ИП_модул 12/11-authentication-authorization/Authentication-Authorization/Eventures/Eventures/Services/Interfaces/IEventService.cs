using Eventures.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Services.Interfaces
{
   public interface IEventService
    {
        void CreateEvent(string name, string place, DateTime start, DateTime end, int totalTickets, decimal pricePerTicket);

        Event[] GetAllEvents();
        Event GetEventById(int id);


        int GetTotalTicketsByEvent(int id);
    }
}
