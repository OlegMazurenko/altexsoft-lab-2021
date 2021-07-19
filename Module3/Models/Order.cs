using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Models
{
    public class Order : BaseModel
    {
        public int UserId { get; set; }
        public string Address { get; set; }
        public IList<Product> Products { get; set; }
        public decimal DeliveryCost { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }

        public Order(string address, IList<Product> products)
        {
            Products = products;
            Address = address;
        }
    }
}
