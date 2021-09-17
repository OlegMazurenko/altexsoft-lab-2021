using DeliveryServiceEF.Domain.Models;
using DeliveryServiceEF.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryServiceEF.Domain.Services;
using DeliveryServiceEF.Domain.Interfaces;

namespace DeliveryServiceEF.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            return _categoryService.GetCategories();
        }

        [HttpGet("{id}")]
        public Category GetById(int id)
        {
            return _categoryService.GetCategory(id);
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            _categoryService.AddCategory(category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return Ok();
        }
    }
}
