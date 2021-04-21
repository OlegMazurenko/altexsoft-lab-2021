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
        public string Seller { get; set; }

        public Product(string name, string description, decimal price, string seller)
        {
            Name = name;
            Description = description;
            Price = price;
            Seller = seller;
        }
    }
}
