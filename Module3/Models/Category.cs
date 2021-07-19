using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Category() { }
    }
}
