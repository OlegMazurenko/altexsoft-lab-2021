using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Web.Filters
{
    public class ProductActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine(context.HttpContext.Request.Body);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine(context.HttpContext.Request.Body);
        }
    }
}
