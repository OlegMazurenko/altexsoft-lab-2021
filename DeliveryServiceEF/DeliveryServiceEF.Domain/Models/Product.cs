using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryServiceEF.Domain.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public User Seller { get; set; }

        public List<Order> Orders = new List<Order>();
    }
}
