using System;
using System.Collections.Generic;
using DeliveryService.Models;

namespace DeliveryService.Interfaces
{
    public interface IUserController
    {
        void AddUser(User user);
        User GetCurrentUser();
        bool CurrentUserExists();
        bool UserExists(string email, string password);
        void SignOutUser();
    }
}
