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
            return storeContext.GetProducts();
        }

        public void CreateProduct(Product product)
        {
            storeContext.SetProduct(product);
        }
    }
}
