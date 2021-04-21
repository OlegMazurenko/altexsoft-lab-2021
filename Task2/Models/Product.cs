﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Task2.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Seller { get; set; }
    }
}
