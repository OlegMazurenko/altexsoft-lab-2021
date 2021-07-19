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

        public User(string email, string password, string name, string phoneNumber, AccessLevel access)
        {
            Email = email;
            Password = password;
            Name = name;
            PhoneNumber = phoneNumber;
            Access = access;
        }

        public User(int id, string email, string password, string name, string phoneNumber, AccessLevel access)
        {
            Id = id;
            Email = email;
            Password = password;
            Name = name;
            PhoneNumber = phoneNumber;
            Access = access;
        }

        public User() { }
    }
}
