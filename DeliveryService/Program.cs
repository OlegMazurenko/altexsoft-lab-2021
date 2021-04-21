using System;
using System.Collections.Generic;
using DeliveryService.Controllers;
using DeliveryService.Models;

namespace DeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            var productController = new ProductController();
            bool end = false;
            while (!end)
            {
                Console.WriteLine("\r\nDeliveryService");
                Console.WriteLine("Введите 1, чтобы войти как покупатель");
                Console.WriteLine("Введите 2, чтобы войти как продавец");
                Console.WriteLine("Введите 0, чтобы выйти");
                string input = Console.ReadLine();

                try
                {
                    switch (Convert.ToInt32(input))
                    {
                        case 1:
                            bool goToOrder = false;
                            var productsToOrder = new List<Product>();
                            while (!goToOrder)
                            {
                                Console.WriteLine("Список товаров:");
                                var products = productController.GetProducts();
                                Console.WriteLine("Имя | Описание | Цена | Продавец");
                                foreach (var product in products)
                                {
                                    Console.WriteLine($"{product.Name} | {product.Description} | {product.Price} | {product.Seller}");
                                }
                                var productsToOrderCount = 0;
                                while (productsToOrderCount < 1)
                                {
                                    Console.WriteLine("Введите имя товара, который хотите заказать");
                                    var inputProductName = Console.ReadLine();
                                    foreach (var product1 in products)
                                    {
                                        if (product1.Name == inputProductName)
                                        {
                                            productsToOrder.Add(product1);
                                            productsToOrderCount += 1;
                                        }
                                    }
                                    if (productsToOrderCount < 1)
                                    {
                                        Console.WriteLine("Не удалось найти товар с таким именем, попробуйте еще раз");
                                    }
                                }
                                Console.WriteLine("Введите 1, чтобы перейти к оформлению заказа");
                                Console.WriteLine("Введите любое другое число, чтобы добавить в заказ другие товары");
                                var input1 = Convert.ToInt32(Console.ReadLine());
                                if (input1 == 1)
                                {
                                    goToOrder = true;
                                }
                            }
                            Console.WriteLine("Введите адресс доставки:");
                            var inputAdress = Console.ReadLine();
                            var order = new Order(inputAdress, productsToOrder);
                            Console.WriteLine("Заказ успешно сделан!");
                            break;
                        case 2:
                            Console.WriteLine("Добавление нового продукта");
                            Console.WriteLine("Введите название продукта:");
                            var productName = Console.ReadLine();
                            Console.WriteLine("Введите описание продукта:");
                            var productDescription = Console.ReadLine();
                            Console.WriteLine("Введите цену продукта:");
                            var productPrice = Convert.ToDecimal(Console.ReadLine());
                            var newProduct = new Product(productName, productDescription, productPrice, "SellerName");
                            productController.CreateProduct(newProduct);
                            Console.WriteLine("Товар успешно добавлен!");
                            break;
                        case 0:
                            end = true;
                            break;
                        default:
                            Console.WriteLine("Введен неправильный номер");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Введены некорректные данные");
                }
            }
        }
    }
}
