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
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            _categoryService.AddCategory(new Category() { Name = "Category123" });
            return _categoryService.GetCategories();
        }

        //  GET /Category/{id?}
        //  POST /Category
        //  PUT /Category/{id}
        //  DELETE /Category/{id}

        //  GET /Order/{id?}
        //  POST /Order
        //  PUT /Order/{id}
        //  DELETE /Order/{id}

        //  GET /Product/{id?}
        //  POST /Product
        //  PUT /Product/{id}
        //  DELETE /Product/{id}

        //  GET /User/{id?}
        //  POST /User
        //  PUT /User/{id}
        //  DELETE /User/{id}
    }
}
