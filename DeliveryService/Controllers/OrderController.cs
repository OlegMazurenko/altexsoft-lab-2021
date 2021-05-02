using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.Controllers
{
    class OrderController : IOrderController
    {
        private readonly IStoreContext storeContext;

        public OrderController(IStoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public void CreateOrder(Order order)
        {
            order.Id = storeContext.Orders.Count > 0 ? storeContext.Orders.Max(x => x.Id) + 1 : 1;
            storeContext.Orders.Add(order);
        }
    }
}
