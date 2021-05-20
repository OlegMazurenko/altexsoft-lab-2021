using DeliveryService.Models;
using System;
using System.Collections.Generic;

namespace DeliveryService.Interfaces
{
    public interface IStoreContext
    {
        IList<Product> Products { get; set; }
        IList<User> Users { get; set; }
        IList<Order> Orders { get; set; }
        User CurrentUser { get; set; }
    }
}
