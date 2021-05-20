using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.Controllers
{
    public class OrderController : IOrderController
    {
        private readonly IStoreContext storeContext;
        private readonly ILogger logger;

        public OrderController(IStoreContext storeContext, ILogger logger)
        {
            this.storeContext = storeContext;
            this.logger = logger;
        }

        public void AddOrder(Order order)
        {
            order.Id = storeContext.Orders.Count > 0 ? storeContext.Orders.Max(x => x.Id) + 1 : 1;
            order.UserId = storeContext.CurrentUser.Id;
            foreach (var product in order.Products)
            {
                order.TotalPrice += product.Price;
            }
            storeContext.Orders.Add(order);
            storeContext.Save();
            if (storeContext.CurrentUser is not null)
            {
                logger.Log($"Пользователь ({storeContext.CurrentUser.Email}) добавил новый заказ (ID: {order.Id})");
            }
            else
            {
                logger.Log($"Добавлен новый заказ (ID: {order.Id})");
            }
        }
    }
}
