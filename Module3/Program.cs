using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Data;

namespace DeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new StoreContext();
            Console.WriteLine("-----Task1-----");
            Task1(data);
            Console.WriteLine("-----Task2-----");
            Task2(data);
            Console.WriteLine("-----Task3-----");
            Task3(data);
            Console.WriteLine("-----Task4-----");
            Task4(data);
            Console.WriteLine("-----Task5-----");
            Task5(data);
        }

        static void Task1(StoreContext data)
        {
            var products = data.Products.OrderBy(p => p.Name).ToList();
            foreach(var product in products)
            {
                Console.WriteLine($"{product.Name}");
            }
        }

        static void Task2(StoreContext data)
        {
            var products = data.Products.Join(data.Users,
                p => p.SellerId,
                u => u.Id,
                (p, u) => new { SellerName = u.Name, ProductName = p.Name });
            Console.WriteLine("Seller Name | Product Name");
            foreach(var product in products)
            {
                Console.WriteLine($"{product.SellerName}     |     {product.ProductName}");
            }
        }

        static void Task3(StoreContext data)
        {
            var categories = data.Categories;
            var products = data.Products;
            Console.WriteLine("Category Name | Products Count");
            foreach (var category in categories)
            {
                var productsInCategory = products.Where(x => x.CategoryId == category.Id).ToList();
                Console.WriteLine($"{category.Name}     |     {productsInCategory.Count}");
            }
        }

        static void Task4(StoreContext data)
        {
            var products = data.Users.GroupJoin(data.Products,
                u => u.Id,
                p => p.SellerId,
                (u, p) => new { SellerName = u.Name, ProductCount = p.Count() })
                .OrderByDescending(x => x.ProductCount);
            Console.WriteLine("Seller Name | Product Count");
            foreach(var product in products)
            {
                Console.WriteLine($"{product.SellerName}     |     {product.ProductCount}");
            }
        }

        static void Task5(StoreContext data)
        {
            Console.WriteLine("----Task5.1----");
            var productsFromSeller1 = data.Products.Where(x => x.SellerId == 1).Select(x => new { x.Name }).ToList();
            var productsFromSeller3 = data.Products.Where(x => x.SellerId == 3).Select(x => new { x.Name }).ToList();

            var intersect = productsFromSeller1.Intersect(productsFromSeller3);
            foreach(var product in intersect)
            {
                Console.WriteLine(product.Name);
            }
            Console.WriteLine("----Task5.2----");
            var except = productsFromSeller1.Except(productsFromSeller3);
            Console.WriteLine("Unique products for Seller1:");
            foreach (var product in except)
            {
                Console.WriteLine(product.Name);
            }
            Console.WriteLine();
            var except2 = productsFromSeller3.Except(productsFromSeller1);
            Console.WriteLine("Unique products for Seller3:");
            foreach (var product in except2)
            {
                Console.WriteLine(product.Name);
            }
        }
    }
}
