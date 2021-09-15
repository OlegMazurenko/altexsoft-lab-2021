using DeliveryServiceEF.Domain.Interfaces;
using DeliveryServiceEF.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _productService.GetProducts();
        }

        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            return _productService.GetProduct(id);
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            _productService.AddProduct(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }
    }
}
