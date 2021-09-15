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
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Product GetProduct(int id)
        {
            return _unitOfWork.Products.GetById(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _unitOfWork.Products.GetAll();
        }

        public void AddProduct(Product product)
        {
            _unitOfWork.Products.Add(product);
            _unitOfWork.Save();
        }

        public void DeleteProduct(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            _unitOfWork.Products.Remove(product);
            _unitOfWork.Save();
        }
    }
}
