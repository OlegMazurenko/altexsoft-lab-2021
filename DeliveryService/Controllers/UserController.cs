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

        public void AddUser(User user)
        {
            user.Id = storeContext.Users.Count > 0 ? storeContext.Users.Max(x => x.Id) + 1 : 1;
            storeContext.Users.Add(user);
        }
    }
}
