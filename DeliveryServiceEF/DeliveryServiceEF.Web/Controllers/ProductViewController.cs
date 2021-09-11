using DeliveryServiceEF.Domain.Interfaces;
using DeliveryServiceEF.Domain.Models;
using DeliveryServiceEF.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Web.Controllers
{
    [Route("mvc/product")]
    [ServiceFilter(typeof(ProductExeptionFilter))]
    public class ProductViewController : Controller
    {
        private readonly IProductService _productService;

        public ProductViewController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ServiceFilter(typeof(ProductActionFilter))]
        public IActionResult Index()
        {
            return View("Index", _productService.GetProducts());
        }

        [HttpGet("details")]
        public IActionResult Details(int id)
        {
            return View("Details", _productService.GetProduct(id));
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Product product)
        {
            _productService.AddProduct(product);
            return View();
        }

        [HttpGet("delete")]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return View();
        }
    }
}
