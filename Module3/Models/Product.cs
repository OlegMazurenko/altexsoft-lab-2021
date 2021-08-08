using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int SellerId { get; set; }
        public int CategoryId { get; set; }
    }
}
