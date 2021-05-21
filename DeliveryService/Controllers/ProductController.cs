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
        private readonly IStoreContext _storeContext;
        private readonly ILogger _logger;

        public ProductController(IStoreContext storeContext, ILogger logger)
        {
            _storeContext = storeContext;
            _logger = logger;
        }

        public IList<Product> GetProducts()
        {
            return _storeContext.Products;
        }

        public void AddProduct(Product product)
        {
            product.Id = _storeContext.Products.Count > 0 ? _storeContext.Products.Max(x => x.Id) + 1 : 1;
            _storeContext.Products.Add(product);
            _storeContext.Save();
            if (_storeContext.CurrentUser is not null)
            {
                if (_storeContext.CurrentUser.Access == User.AccessLevel.Seller)
                {
                    product.SellerId = _storeContext.CurrentUser.Id;
                }
                _logger.Log($"Пользователь ({_storeContext.CurrentUser.Email}) добавил новый товар ({product.Name})");
            }
            else
            {
                _logger.Log($"Добавлен новый товар ({product.Name})");
            }
        }
    }
}
