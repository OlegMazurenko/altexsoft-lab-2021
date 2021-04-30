using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.Controllers
{
    public class ProductController : IProductController
    {
        private readonly IStoreContext storeContext;

        public ProductController(IStoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public IList<Product> GetProducts()
        {
            return storeContext.Products;
        }

        public void CreateProduct(Product product)
        {
            product.Id = storeContext.Products.Count > 0 ? storeContext.Products[storeContext.Products.Count - 1].Id + 1 : 0;
            storeContext.Products.Add(product);
        }
    }
}
