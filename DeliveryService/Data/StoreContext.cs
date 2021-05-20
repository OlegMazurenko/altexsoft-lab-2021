using DeliveryService.Interfaces;
using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data
{
    public class StoreContext : IStoreContext
    {
        public IList<Product> Products { get; set; }
        public IList<User> Users { get; set; }
        public IList<Order> Orders { get; set; }
        public User CurrentUser { get; set; }

        public StoreContext()
        {
            Products = new List<Product>();
            Users = new List<User>();
            Orders = new List<Order>();
        }
    }
}
