using DeliveryServiceEF.Domain.Models;
using System.Collections.Generic;

namespace DeliveryServiceEF.Domain.Interfaces
{
    public interface IOrderService
    {
        void AddOrder(Order order);
        void DeleteOrder(int id);
        Order GetOrder(int id);
        IEnumerable<Order> GetOrders();
    }
}