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
            var context = new StoreContext();
            var logger = new Logger();
            var productController = new ProductController(context, logger);
            var userController = new UserController(context, logger);
            var orderController = new OrderController(context, logger);

            productController.AddProduct(new Product("Product1", "description", 10));
            productController.AddProduct(new Product("Product2", "description", 20));
            productController.AddProduct(new Product("Product3", "description", 30));
            userController.AddUser(new User("Seller@ro.ru", "password", "John", "0978884433", "Seller"));
            userController.AddUser(new User("Buyer@ro.ru", "password", "Alex", "0975554433", "Buyer"));

            var presenter = new Presenter(productController, userController, orderController);
            presenter.ShowMenu();
        }
    }
}
