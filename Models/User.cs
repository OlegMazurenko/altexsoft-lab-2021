﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Task2.Models
{
    public class User : BaseModel
    {
        public int PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
