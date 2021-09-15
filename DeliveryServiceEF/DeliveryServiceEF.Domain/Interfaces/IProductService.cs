using DeliveryServiceEF.Domain.Models;
using System.Collections.Generic;

namespace DeliveryServiceEF.Domain.Interfaces
{
    public interface IProductService
    {
        void AddProduct(Product product);
        void DeleteProduct(int id);
        Product GetProduct(int id);
        IEnumerable<Product> GetProducts();
    }
}