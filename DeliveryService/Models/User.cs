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

        public User(string email, string password, string name, string phoneNumber)
        {
            Email = email;
            Password = password;
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
