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
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Order GetOrder(int id)
        {
            return _unitOfWork.Orders.GetById(id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _unitOfWork.Orders.GetAll();
        }

        public void AddOrder(Order order)
        {
            _unitOfWork.Orders.Add(order);
            _unitOfWork.Save();
        }

        public void DeleteOrder(int id)
        {
            var order = _unitOfWork.Orders.GetById(id);
            _unitOfWork.Orders.Remove(order);
            _unitOfWork.Save();
        }
    }
}
