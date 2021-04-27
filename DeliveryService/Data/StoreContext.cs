using DeliveryService.Interfaces;
using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data
{
    public class StoreContext : IStoreContext
    {
        public IList<Product> Products { get; set; }

        public StoreContext()
        {
            Products = new List<Product>();
        }

        public IList<Product> GetProducts()
        {
            return Products;
        }

        public void SetProduct(Product product)
        {
            product.Id = Products.Count > 0 ? Products[Products.Count - 1].Id + 1 : 0;
            Products.Add(product);
        }
    }
}
