using DeliveryServiceEF.Domain.Models;
using DeliveryServiceEF.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryServiceEF.Domain.Controllers;

namespace DeliveryServiceEF.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly CategoryController _categoryController;

        public ExampleController(CategoryController categoryController)
        {
            _categoryController = categoryController;
        }

        //  GET /Example
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            _categoryController.AddCategory(new Category() { Name = "Category123" });
            return _categoryController.GetCategories();
        }
    }
}
