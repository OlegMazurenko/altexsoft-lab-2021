using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Models
{
    public class User : BaseModel
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public AccessLevel Access { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
