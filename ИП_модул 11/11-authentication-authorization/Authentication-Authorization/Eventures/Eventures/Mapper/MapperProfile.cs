using AutoMapper;
using Eventures.Domain;
using Eventures.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Mapper
{
    public class MapperProfile :Profile
    {
        public MapperProfile()
        {
            this.CreateMap<Order, AllOrdersViewModel>()
               .ForMember(o => o.EventName,
                   e => e.MapFrom(s => s.Event.Name))
               .ForMember(o => o.CustomerName,
                   e => e.MapFrom(s => s.Customer.UserName))
               .ForMember(o => o.OrderedOn,
                   e => e.MapFrom(s => s.OrderedOn.ToString("dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture)));
        }        
    }
}
