using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.Controllers;
using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService
{
    public class Presenter : IPresenter
    {
        private readonly IProductController productController;
        
        public Presenter(IProductController productController)
        {
            this.productController = productController;
        }

        public void ShowMenu()
        {
            bool end = false;
            while (!end)
            {
                Console.WriteLine("\r\nDeliveryService");
                Console.WriteLine("Введите 1, чтобы войти как покупатель");
                Console.WriteLine("Введите 2, чтобы войти как продавец");
                Console.WriteLine("Введите 3, чтобы выйти");
                int.TryParse(Console.ReadLine(), out var number);

                switch (number)
                {
                    case 1:
                        MakeOrder();
                        break;
                    case 2:
                        CreateProduct();
                        break;
                    case 3:
                        end = true;
                        break;
                    case 0:
                        Console.WriteLine("Нужно ввести число от 1 до 3");
                        break;
                    default:
                        Console.WriteLine("Введен неправильный номер");
                        break;
                }
            }
        }

        public void MakeOrder()
        {
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
                Console.WriteLine("Или введите любой другой символ, чтобы добавить в заказ другие товары");
                int.TryParse(Console.ReadLine(), out var number);
                if (number == 1)
                {
                    goToOrder = true;
                }
            }
            Console.WriteLine("Введите адресс доставки:");
            var inputAdress = Console.ReadLine();
            var order = new Order(inputAdress, productsToOrder);
            Console.WriteLine("Заказ успешно сделан!");
        }

        public void CreateProduct()
        {
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
        }
    }
}
