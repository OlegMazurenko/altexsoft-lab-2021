using DeliveryService.Models;
using System;
using System.Collections.Generic;

namespace DeliveryService.Data
{
    public class StoreContext
    {
        public IList<Product> Products { get; set; }
        public IList<User> Users { get; set; }
        public IList<Order> Orders { get; set; }
        public IList<Category> Categories { get; set; }

        public StoreContext()
        {
            FillProducts();
            FillUsers();
            FillCategories();
        }

        public void FillProducts()
        {
            Products = new List<Product>
            {
                new Product
                {
                    Id = 1, Name = "Product1", Description = "desc", SellerId = 1, CategoryId = 3
                },
                new Product
                {
                    Id = 2, Name = "Product2", Description = "desc", SellerId = 1, CategoryId = 1
                },
                new Product
                {
                    Id = 3, Name = "Product3", Description = "desc", SellerId = 2, CategoryId = 1
                },
                new Product
                {
                    Id = 4, Name = "Product4", Description = "desc", SellerId = 2, CategoryId = 2
                },
                new Product
                {
                    Id = 5, Name = "Product5", Description = "desc", SellerId = 3, CategoryId = 2
                }
            };
        }

        public void FillUsers()
        {
            Users = new List<User>
            {
                new User
                {
                    Id = 1, Name = "Seller1", Email = "example@ro.ru", Password = "123", PhoneNumber = "0979878787", Access = AccessLevel.Seller
                },
                new User
                {
                    Id = 2, Name = "Seller2", Email = "example@ro.ru", Password = "123", PhoneNumber = "0979878787", Access = AccessLevel.Seller
                },
                new User
                {
                    Id = 3, Name = "Seller3", Email = "example@ro.ru", Password = "123", PhoneNumber = "0979878787", Access = AccessLevel.Seller
                }
            };
        }

        public void FillCategories()
        {
            Categories = new List<Category>
            {
                new Category
                {
                    Id = 1, Name = "Category1"
                },
                new Category
                {
                    Id = 2, Name = "Category2"
                },
                new Category
                {
                    Id = 3, Name = "Category3"
                }
            };
        }
    }
}
