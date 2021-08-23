using DeliveryServiceEF.Domain.Models;
using System.Collections.Generic;

namespace DeliveryServiceEF.Domain.Interfaces
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        void DeleteCategory(int id);
        IEnumerable<Category> GetCategories();
        Category GetCategory(int id);
    }
}