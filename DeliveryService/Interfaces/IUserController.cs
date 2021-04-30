using System;
using System.Collections.Generic;
using DeliveryService.Models;

namespace DeliveryService.Interfaces
{
    public interface IUserController
    {
        void CreateUser(User user);
    }
}
