using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface IProductController
    {
        IList<Product> GetProducts();
        void CreateProduct(Product product);
    }
}
