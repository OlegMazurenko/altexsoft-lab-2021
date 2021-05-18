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

        public enum AccessLevel
        {
            Admin,
            Buyer,
            Seller
        }

        public User(string email, string password, string name, string phoneNumber, AccessLevel accessLevel)
        {
            Email = email;
            Password = password;
            Name = name;
            PhoneNumber = phoneNumber;
            Access = accessLevel;
        }
    }
}
