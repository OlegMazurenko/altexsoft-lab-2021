using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Data;
using DeliveryService.Models;

namespace DeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new StoreContext();
            Console.WriteLine("-----Task1-----");
            var task1Products = Task1(data);
            foreach (var product in task1Products)
            {
                Console.WriteLine($"{product.Name}");
            }

            Console.WriteLine("-----Task2-----");
            var task2Products = Task2(data);
            Console.WriteLine("Seller Name | Product Name");
            foreach (var product in task2Products)
            {
                Console.WriteLine($"{product.Item1}     |     {product.Item2}");
            }

            Console.WriteLine("-----Task3-----");
            var task3Categories = Task3(data);
            Console.WriteLine("Category Name | Products Count");
            foreach (var category in task3Categories)
            {
                Console.WriteLine($"{category.Item1}     |     {category.Item2}");
            }

            Console.WriteLine("-----Task4-----");
            var task4Products = Task4(data);
            Console.WriteLine("Seller Name | Product Count");
            foreach (var product in task4Products)
            {
                Console.WriteLine($"{product.Item1}     |     {product.Item2}");
            }

            Console.WriteLine("----Task5.1----");
            var intersect = Task5Intersect(data);
            foreach (var product in intersect)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("----Task5.2----");
            Console.WriteLine("Unique products for Seller1:");
            var except = Task5Except1(data);
            foreach (var product in except)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("Unique products for Seller3:");
            var except2 = Task5Except2(data);
            foreach (var product in except2)
            {
                Console.WriteLine(product);
            }
        }

        static List<Product> Task1(StoreContext data)
        {
            return data.Products.OrderBy(p => p.Name).ToList();
        }

        static List<(string, string)> Task2(StoreContext data)
        {
            return data.Products.Select(x => (x.Seller.Name, x.Name)).ToList();
        }

        static List<(string, int)> Task3(StoreContext data)
        {
            return data.Categories.GroupJoin(data.Products,
                c => c.Id,
                p => p.CategoryId,
                (c, p) => new { CategoryName = c.Name, ProductCount = p.Count() })
                .Select(x => (x.CategoryName, x.ProductCount)).ToList();
        }

        static List<(string, int)> Task4(StoreContext data)
        {
            return data.Users.GroupJoin(data.Products,
                u => u.Id,
                p => p.Seller.Id,
                (u, p) => new { SellerName = u.Name, ProductCount = p.Count() })
                .OrderByDescending(x => x.ProductCount)
                .Select(x => (x.SellerName, x.ProductCount)).ToList();
        }

        static List<string> Task5Intersect(StoreContext data)
        {
            var productsFromSeller1 = data.Products.Where(x => x.Seller.Id == 1).Select(x => new { x.Name }).ToList();
            var productsFromSeller3 = data.Products.Where(x => x.Seller.Id == 3).Select(x => new { x.Name }).ToList();

            return productsFromSeller1.Intersect(productsFromSeller3).Select(x => x.Name).ToList();
        }

        static List<string> Task5Except1(StoreContext data)
        {
            var productsFromSeller1 = data.Products.Where(x => x.Seller.Id == 1).Select(x => new { x.Name }).ToList();
            var productsFromSeller3 = data.Products.Where(x => x.Seller.Id == 3).Select(x => new { x.Name }).ToList();

            return productsFromSeller1.Except(productsFromSeller3).Select(x => x.Name).ToList();
        }

        static List<string> Task5Except2(StoreContext data)
        {
            var productsFromSeller1 = data.Products.Where(x => x.Seller.Id == 1).Select(x => new { x.Name }).ToList();
            var productsFromSeller3 = data.Products.Where(x => x.Seller.Id == 3).Select(x => new { x.Name }).ToList();

            return productsFromSeller3.Except(productsFromSeller1).Select(x => x.Name).ToList();
        }
    }
}
