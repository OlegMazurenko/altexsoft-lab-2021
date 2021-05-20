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
            var productController = new ProductController(context, logger);
            var userController = new UserController(context, logger);
            var orderController = new OrderController(context, logger);
            var presenter = new Presenter(productController, userController, orderController);
            presenter.ShowMenu();
        }
    }
}
