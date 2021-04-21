using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.Models;

namespace DeliveryService.Controllers
{
    public class ProductController
    {
        public List<Product> GetProducts()
        {
            var products = new List<Product>();
            var product1 = new Product("Product1", "description", 10, "Seller1");
            var product2 = new Product("Product2", "description", 20, "Seller2");
            var product3 = new Product("Product3", "description", 30, "Seller3");
            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            return products;
        }

        public void CreateProduct(Product product)
        {
            
        }
    }
}
