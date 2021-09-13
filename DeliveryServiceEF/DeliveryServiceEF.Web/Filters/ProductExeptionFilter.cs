using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
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
        private readonly IWebHostEnvironment _env;

        public ProductExeptionFilter(ILogger logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            if (_env.IsEnvironment("Production"))
            {
                _logger.LogInformation($"Error: {context.Exception.Message}");
            }
            else
            {
                _logger.LogInformation($"Error: {context.Exception.Message} {context.Exception.StackTrace}");
            }
            context.ExceptionHandled = true;
        }
    }
}
