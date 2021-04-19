using System;
using System.Collections.Generic;
using System.Text;

namespace Task2.Models
{
    public class Order : BaseModel
    {
        public int UserId { get; set; }
        public string Address { get; set; }
        public List<Product> ProductList { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
