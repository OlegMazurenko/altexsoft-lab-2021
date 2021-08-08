using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            FillCategories();
            FillUsers();
            FillProducts();
        }

        public void FillProducts()
        {
            Products = new List<Product>
            {
                new Product
                {
                    Id = 1, Name = "Pizza", Description = "desc", Seller = Users.First(x => x.Id == 1), CategoryId = 3
                },
                new Product
                {
                    Id = 2, Name = "Soup", Description = "desc", Seller = Users.First(x => x.Id == 2), CategoryId = 1
                },
                new Product
                {
                    Id = 3, Name = "Steak", Description = "desc", Seller = Users.First(x => x.Id == 1), CategoryId = 1
                },
                new Product
                {
                    Id = 4, Name = "Toast", Description = "desc", Seller = Users.First(x => x.Id == 2), CategoryId = 2
                },
                new Product
                {
                    Id = 5, Name = "Salad", Description = "desc", Seller = Users.First(x => x.Id == 3), CategoryId = 2
                },
                new Product
                {
                    Id = 6, Name = "Pizza", Description = "desc", Seller = Users.First(x => x.Id == 3), CategoryId = 3
                },
                new Product
                {
                    Id = 7, Name = "Steak", Description = "desc", Seller = Users.First(x => x.Id == 3), CategoryId = 1
                },
                new Product
                {
                    Id = 8, Name = "Sushi", Description = "desc", Seller = Users.First(x => x.Id == 1), CategoryId = 2
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
