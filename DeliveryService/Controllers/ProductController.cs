using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.Interfaces;
using DeliveryService.Models;
using DeliveryService.Data;

namespace DeliveryService.Controllers
{
    public class ProductController : IProductController
    {
        private readonly IStoreContext _storeContext;
        private readonly ILogger _logger;
        private readonly ICache _cache;

        public ProductController(IStoreContext storeContext, ILogger logger, ICache cache)
        {
            _storeContext = storeContext;
            _logger = logger;
            _cache = cache;
        }

        public IList<Product> GetProducts()
        {
            return (List<Product>)_cache.GetFromCache((int)Cache.CollectionType.Product, () => _storeContext.Products);
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
