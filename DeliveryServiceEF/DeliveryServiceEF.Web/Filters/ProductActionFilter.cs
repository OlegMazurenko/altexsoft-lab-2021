using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Web.Filters
{
    public class ProductActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            using var reader = new StreamReader(context.HttpContext.Request.Body);
            Console.WriteLine($"Request.Body: {reader.ReadToEnd()}");
        }
    }
}
