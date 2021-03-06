using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Interfaces;
using DeliveryService.Models;
using System.Threading.Tasks;

namespace DeliveryService.Controllers
{
    public class OrderController : IOrderController
    {
        private readonly IStoreContext _storeContext;
        private readonly ILogger _logger;
        private readonly ICurrencyController _currencyController;

        public OrderController(IStoreContext storeContext, ILogger logger, ICurrencyController currencyController)
        {
            _storeContext = storeContext;
            _logger = logger;
            _currencyController = currencyController;

        }

        public void AddOrder(Order order)
        {
            order.Id = _storeContext.Orders.Count > 0 ? _storeContext.Orders.Max(x => x.Id) + 1 : 1;
            order.UserId = _storeContext.CurrentUser.Id;
            _storeContext.Orders.Add(order);
            _storeContext.Save();
            if (_storeContext.CurrentUser is not null)
            {
                _logger.Log($"Пользователь ({_storeContext.CurrentUser.Email}) добавил новый заказ (ID: {order.Id})");
            }
            else
            {
                _logger.Log($"Добавлен новый заказ (ID: {order.Id})");
            }
        }

        public async Task<decimal> ConvertToUsdAsync(decimal price)
        {
            return price / await _currencyController.GetUsdRateAsync();
        }
    }
}
