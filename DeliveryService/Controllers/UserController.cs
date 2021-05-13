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
        private readonly ILogger logger;

        public UserController(IStoreContext storeContext, ILogger logger)
        {
            this.storeContext = storeContext;
            this.logger = logger;
        }

        public void AddUser(User user)
        {
            user.Id = storeContext.Users.Count > 0 ? storeContext.Users.Max(x => x.Id) + 1 : 1;
            storeContext.Users.Add(user);
            logger.Log($"Создан новый пользователь ({user.Email}).");
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
                        SetCurrentUser(user);
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
            logger.Log($"Пользователь ({user.Email}) вошел в систему.");
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
