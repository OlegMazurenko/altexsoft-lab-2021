using DeliveryServiceEF.Domain.Interfaces;
using DeliveryServiceEF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Domain.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork UnitOfWork { get; }

        public UserService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public User GetUser(int id)
        {
            return UnitOfWork.Users.GetById(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return UnitOfWork.Users.GetAll();
        }

        public void AddUser(User user)
        {
            UnitOfWork.Users.Add(user);
            UnitOfWork.Save();
        }

        public void DeleteUser(int id)
        {
            var user = UnitOfWork.Users.GetById(id);
            UnitOfWork.Users.Remove(user);
            UnitOfWork.Save();
        }
    }
}
