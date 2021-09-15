using DeliveryServiceEF.Domain.Interfaces;
using DeliveryServiceEF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Category GetCategory(int id)
        {
            return _unitOfWork.Categories.GetById(id);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _unitOfWork.Categories.GetAll();
        }

        public void AddCategory(Category category)
        {
            _unitOfWork.Categories.Add(category);
            _unitOfWork.Save();
        }

        public void DeleteCategory(int id)
        {
            var category = _unitOfWork.Categories.GetById(id);
            _unitOfWork.Categories.Remove(category);
            _unitOfWork.Save();
        }
    }
}
