using DeliveryServiceEF.Domain.Interfaces;
using DeliveryServiceEF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Domain.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork UnitOfWork { get; }

        public ProductService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public Product GetProduct(int id)
        {
            return UnitOfWork.Products.GetById(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return UnitOfWork.Products.GetAll();
        }

        public void AddProduct(Product product)
        {
            UnitOfWork.Products.Add(product);
            UnitOfWork.Save();
        }

        public void DeleteProduct(int id)
        {
            var product = UnitOfWork.Products.GetById(id);
            UnitOfWork.Products.Remove(product);
            UnitOfWork.Save();
        }
    }
}
