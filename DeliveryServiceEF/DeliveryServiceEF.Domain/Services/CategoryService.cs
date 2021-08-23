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
        private IUnitOfWork UnitOfWork { get; }

        public CategoryService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public Category GetCategory(int id)
        {
            return UnitOfWork.Categories.GetById(id);
        }

        public IEnumerable<Category> GetCategories()
        {
            return UnitOfWork.Categories.GetAll();
        }

        public void AddCategory(Category category)
        {
            UnitOfWork.Categories.Add(category);
            UnitOfWork.Save();
        }

        public void DeleteCategory(int id)
        {
            var category = UnitOfWork.Categories.GetById(id);
            UnitOfWork.Categories.Remove(category);
            UnitOfWork.Save();
        }
    }
}
