using DeliveryServiceEF.Domain.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Web.Helpers
{
    public static class ProductHtmlHelper
    {
        public static HtmlString ShowProductList(IEnumerable<Product> products)
        {
            var result = string.Empty;
            foreach (var product in products)
            {
                result += $"<span>{product.Id} </span>";
                result += $"<span> {product.Name} </span>";
                result += "<br/>";
            }
            return new HtmlString(result);
        }
    }
}
