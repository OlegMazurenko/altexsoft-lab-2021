using DeliveryService.Interfaces;
using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryService.Controllers
{
    public class UserController : IUserController
    {
        private readonly IStoreContext _storeContext;
        private readonly ILogger _logger;

        public UserController(IStoreContext storeContext, ILogger logger)
        {
            _storeContext = storeContext;
            _logger = logger;
            if (storeContext.Users.Count == 0)
            {
                AddUser(new User("Seller@ro.ru", "password", "John", "0978884433", User.AccessLevel.Seller));
                AddUser(new User("Buyer@ro.ru", "password", "Alex", "0975554433", User.AccessLevel.Buyer));
                storeContext.Save();
            }
        }

        public void AddUser(User user)
        {
            user.Id = _storeContext.Users.Count > 0 ? _storeContext.Users.Max(x => x.Id) + 1 : 1;
            _storeContext.Users.Add(user);
            _storeContext.Save();
            _logger.Log($"Создан новый пользователь ({user.Email}).");
        }

        public bool UserIsExists(string email, string password)
        {
            var isExist = false;
            if (_storeContext.Users is not null)
            {
                foreach (var user in _storeContext.Users)
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
            return _storeContext.CurrentUser;
        }

        public void SetCurrentUser(User user)
        {
            _storeContext.CurrentUser = user;
            _logger.Log($"Пользователь ({user.Email}) вошел в систему.");
        }

        public void SignOutUser()
        {
            _storeContext.CurrentUser = null;
        }

        public bool CurrentUserIsExists()
        {
            return _storeContext.CurrentUser is not null;
        }
    }
}
