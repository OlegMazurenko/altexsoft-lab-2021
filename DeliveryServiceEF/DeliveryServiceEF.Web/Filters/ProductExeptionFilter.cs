using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Web.Filters
{
    public class ProductExeptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        public ProductExeptionFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            _logger.LogInformation(context.Exception.Message);
        }
    }
}
