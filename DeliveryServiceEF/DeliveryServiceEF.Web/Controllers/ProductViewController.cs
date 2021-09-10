using DeliveryServiceEF.Domain.Interfaces;
using DeliveryServiceEF.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Web.Controllers
{
    [Route("mvc/product")]
    public class ProductViewController : Controller
    {
        private readonly IProductService _productService;

        public ProductViewController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index", _productService.GetProducts());
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
