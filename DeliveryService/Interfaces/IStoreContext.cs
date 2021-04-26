using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface IStoreContext
    {
        IList<Product> Products { get; set; }
        IList<Product> GetProducts();
        void SetProduct(Product product);
    }
}
