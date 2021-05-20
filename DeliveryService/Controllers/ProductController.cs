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
        private readonly ILogger logger;

        public ProductController(IStoreContext storeContext, ILogger logger)
        {
            this.storeContext = storeContext;
            this.logger = logger;
        }

        public IList<Product> GetProducts()
        {
            return storeContext.Products;
        }

        public void AddProduct(Product product)
        {
            product.Id = storeContext.Products.Count > 0 ? storeContext.Products.Max(x => x.Id) + 1 : 1;
            storeContext.Products.Add(product);
            if (storeContext.CurrentUser is not null)
            {
                if (storeContext.CurrentUser.Access == User.AccessLevel.Seller)
                {
                    product.SellerId = storeContext.CurrentUser.Id;
                }
                logger.Log($"Пользователь ({storeContext.CurrentUser.Email}) добавил новый товар ({product.Name})");
            }
            else
            {
                logger.Log($"Добавлен новый товар ({product.Name})");
            }
        }
    }
}
