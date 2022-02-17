using Eventures.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Services.Interfaces
{
    public interface IOrderService
    {
        void OrderTickets(int eventId, string username, int tickets);

        Order[] GetAllOrders();

        Order[] GetMyOrders(string userId);
    }
}
