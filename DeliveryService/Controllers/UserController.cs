using DeliveryService.Interfaces;
using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryService.Controllers
{
    public class UserController : IUserController
    {
        private readonly IStoreContext storeContext;

        public UserController(IStoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public void CreateUser(User user)
        {
            storeContext.Users.Add(user);
        }
    }
}
