using AutoMapper;
using Eventures.Data;
using Eventures.Domain;
using Eventures.Filters;
using Eventures.Services;
using Eventures.Services.Interfaces;
using Eventures.ViewModels.Events;
using Eventures.ViewModels.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Eventures.Controllers
{
    public class OrderController : Controller
    {
        private readonly IEventService eventService;
        private readonly IMapper mapper;
        private readonly IOrderService orderService;
        public OrderController(IEventService eventService,IOrderService orderService,IMapper mapper)
        {
            this.eventService = eventService;
            this.orderService = orderService;
            this.mapper = mapper;
        }
        [Authorize]
        [HttpPost]
        public IActionResult OrderTickets(CreateOrderViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("All", "Event", model);
            }
            var totalTickets = this.eventService.GetTotalTicketsByEvent(model.EventId);
            if (totalTickets < model.Tickets)
            {
                this.ViewData["Error"] = "There are not enough tickets!";
                return this.RedirectToAction("All", "Event", model);
            }
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            this.orderService.OrderTickets(model.EventId, userId, model.Tickets);
            return this.RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult All()
        {
            var orders = this.orderService.GetAllOrders();
            var ordersViewModel = this.mapper.Map<Order[], IEnumerable<AllOrdersViewModel>>(orders);
            return this.View(ordersViewModel);
        }
    }
}
