using AutoMapper;
using Eventures.Data;
using Eventures.Domain;
using Eventures.Filters;
using Eventures.Services.Interfaces;
using Eventures.ViewModels.Events;
using Eventures.ViewModels.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Eventures.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IEventService eventsService;
        private readonly IOrderService orderService;
        public EventController(ApplicationDbContext context, ILogger<EventController> logger, IEventService eventsService,IOrderService orderService,IMapper mapper)
        {
            this.eventsService = eventsService;
            this.context = context;
            this.logger = logger;
            this.orderService = orderService;
            this.mapper = mapper;
        }
        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(AdminActivityLoggerFilter))]
        public IActionResult Create(CreateEventViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.eventsService.CreateEvent(model.Name, model.Place, model.Start, model.End, model.TotalTickets, model.PricePerTicket);
                this.logger.LogInformation($"Event created: {model.Name}", model);
                return RedirectToAction("All");
            }
            else
            {
                return this.View(model);
            }
        }
        [HttpGet]
        public IActionResult All()
        {
            List<EventViewModel> events = context.Events
                .Select(eventDb => new EventViewModel
                {
                    Name = eventDb.Name,
                    Place = eventDb.Place,
                    Start = eventDb.Start,
                    End = eventDb.End
                })
                .OrderByDescending(e => e.Start)
                .ToList();

            return this.View(events);
        }
        public IActionResult MyEvents()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var orders = this.orderService.GetMyOrders(userId);
            var ordersViewModel = this.mapper.Map<Order[], IEnumerable<MyOrderViewModel>>(orders);
            return this.View(ordersViewModel);
        }
    }
}
