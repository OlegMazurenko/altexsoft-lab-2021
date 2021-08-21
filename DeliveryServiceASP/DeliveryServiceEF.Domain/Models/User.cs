using DeliveryServiceEF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryServiceEF.Domain.Models
{
    public class User : BaseModel
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AccessLevel Access { get; set; }
        public List<Order> Orders { get; set; }
    }
}
