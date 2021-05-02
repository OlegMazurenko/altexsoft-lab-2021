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
            var productController = new ProductController(context);
            var userController = new UserController(context);
            var orderController = new OrderController(context);

            productController.AddProduct(new Product("Product1", "description", 10, "Seller1"));
            productController.AddProduct(new Product("Product2", "description", 20, "Seller2"));
            productController.AddProduct(new Product("Product3", "description", 30, "Seller3"));

            var presenter = new Presenter(productController, userController, orderController);
            presenter.ShowMenu();
        }
    }
}
