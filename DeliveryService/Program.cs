using System;
using System.Collections.Generic;
using DeliveryService.Controllers;
using DeliveryService.Data;
using DeliveryService.Models;

namespace DeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileManager = new JsonManager();
            var context = new StoreContext(fileManager);
            var logger = new Logger();
            var cache = new Cache();
            var productController = new ProductController(context, logger, cache);
            var userController = new UserController(context, logger);
            var orderController = new OrderController(context, logger);
            if (context.Users.Count == 0)
            {
                userController.AddUser(new User("Seller@ro.ru", "password", "John", "0978884433", User.AccessLevel.Seller));
                userController.AddUser(new User("Buyer@ro.ru", "password", "Alex", "0975554433", User.AccessLevel.Buyer));
                context.Save();
            }
            var presenter = new Presenter(productController, userController, orderController);
            presenter.ShowMenu();
        }
    }
}
