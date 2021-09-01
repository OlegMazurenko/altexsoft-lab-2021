using DeliveryServiceEF.Domain.Interfaces;
using DeliveryServiceEF.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<Order> GetAll()
        {
            return _orderService.GetOrders();
        }

        [HttpGet("{id}")]
        public Order GetById(int id)
        {
            return _orderService.GetOrder(id);
        }

        [HttpPost]
        public void Add(Order order)
        {
            _orderService.AddOrder(order);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _orderService.DeleteOrder(id);
        }
    }
}
