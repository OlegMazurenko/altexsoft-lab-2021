using System;
using System.Collections.Generic;
using DeliveryService.Models;

namespace DeliveryService.Interfaces
{
    public interface IOrderController
    {
        void AddOrder(Order order);
    }
}
