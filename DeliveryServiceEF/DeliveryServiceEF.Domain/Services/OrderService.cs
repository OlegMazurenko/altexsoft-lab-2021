using DeliveryServiceEF.Domain.Interfaces;
using DeliveryServiceEF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Domain.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork UnitOfWork { get; }

        public OrderService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public Order GetOrder(int id)
        {
            return UnitOfWork.Orders.GetById(id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return UnitOfWork.Orders.GetAll();
        }

        public void AddOrder(Order order)
        {
            UnitOfWork.Orders.Add(order);
            UnitOfWork.Save();
        }

        public void DeleteOrder(int id)
        {
            var order = UnitOfWork.Orders.GetById(id);
            UnitOfWork.Orders.Remove(order);
            UnitOfWork.Save();
        }
    }
}
