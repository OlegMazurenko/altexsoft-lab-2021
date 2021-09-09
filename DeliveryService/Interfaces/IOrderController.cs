using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeliveryService.Models;

namespace DeliveryService.Interfaces
{
    public interface IOrderController
    {
        void AddOrder(Order order);
        Task<decimal> ConvertToUsdAsync(decimal price);
    }
}
