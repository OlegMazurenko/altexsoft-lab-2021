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

        public bool UserExists(string email, string password)
        {
            var isExist = false;
            if (storeContext.Users is not null)
            {
                foreach (var user in storeContext.Users)
                {
                    if (user.Email == email && user.Password == password)
                    {
                        isExist = true;
                        storeContext.CurrentUser = user;
                    }
                }
            }
            return isExist;
        }

        public User GetCurrentUser()
        {
            return storeContext.CurrentUser;
        }

        public void SetCurrentUser(User user)
        {
            storeContext.CurrentUser = user;
        }

        public void SignOutUser()
        {
            storeContext.CurrentUser = null;
        }

        public bool CurrentUserExists()
        {
            return storeContext.CurrentUser is not null;
        }
    }
}
