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
        //  GET /Example
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var categoryController = new CategoryController(new UnitOfWork(new DataContext()));
            categoryController.AddCategory(new Category() { Name = "Category123" });
            return categoryController.GetCategories();
        }
    }
}
