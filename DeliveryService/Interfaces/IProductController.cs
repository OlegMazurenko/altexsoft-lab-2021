using DeliveryService.Models;
using System;
using System.Collections.Generic;

namespace DeliveryService.Interfaces
{
    public interface IProductController
    {
        IList<Product> GetProducts();
        void CreateProduct(Product product);
    }
}
