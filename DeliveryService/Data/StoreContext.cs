using DeliveryService.Interfaces;
using DeliveryService.Models;
using System;
using System.Collections.Generic;

namespace DeliveryService.Data
{
    public class StoreContext : IStoreContext
    {
        private readonly IFileManager _fileManager;
        public IList<Product> Products { get; set; }
        public IList<User> Users { get; set; }
        public IList<Order> Orders { get; set; }
        public User CurrentUser { get; set; }

        public StoreContext(IFileManager fileManager)
        {
            _fileManager = fileManager;
            Products = _fileManager.LoadFromFile<Product>("Products.json");
            Users = _fileManager.LoadFromFile<User>("Users.json");
            Orders = _fileManager.LoadFromFile<Order>("Orders.json");
        }

        public void Save()
        {
            _fileManager.SaveToFile(Products, "Products.json");
            _fileManager.SaveToFile(Users, "Users.json");
            _fileManager.SaveToFile(Orders, "Orders.json");
        }
    }
}
