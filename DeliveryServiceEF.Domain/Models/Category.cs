using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryServiceEF.Domain.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }
        public IList<Product> Products { get; set; }
    }
}
