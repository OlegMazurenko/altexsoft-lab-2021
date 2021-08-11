using DeliveryServiceEF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryServiceEF.Domain.Models
{
    public class Order : BaseModel
    {
        public int UserId { get; set; }
        public string Address { get; set; }
        public decimal DeliveryCost { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }

        public List<Product> Products = new List<Product>();
    }
}
