using Eventures.ViewModels.Events;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Filters
{
    public class AdminActivityLoggerFilter :ActionFilterAttribute
    {
        private readonly ILogger logger;
        private CreateEventViewModel model;

        public AdminActivityLoggerFilter(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger<AdminActivityLoggerFilter>();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            this.model = context.ActionArguments.Values.OfType<CreateEventViewModel>().Single();

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (this.model != null)
            {
                var User = context.HttpContext.User.Identity.Name;
                var EventName = this.model.Name;
                var EventStart = this.model.Start;
                var EventEnd = this.model.End;
                this.logger.LogInformation($"[{DateTime.UtcNow}] Administrator {User} create event {EventName} ({EventStart} / {EventEnd}).");
            }

            base.OnActionExecuted(context);
        }
    }
}
