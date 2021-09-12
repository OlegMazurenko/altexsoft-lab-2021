using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryServiceEF.Domain.Models
{
    public class Product : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public User Seller { get; set; }

        public List<Order> Orders = new List<Order>();
    }
}
