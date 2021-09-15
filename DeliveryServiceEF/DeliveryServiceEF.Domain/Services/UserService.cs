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
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User GetUser(int id)
        {
            return _unitOfWork.Users.GetById(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _unitOfWork.Users.GetAll();
        }

        public void AddUser(User user)
        {
            _unitOfWork.Users.Add(user);
            _unitOfWork.Save();
        }

        public void DeleteUser(int id)
        {
            var user = _unitOfWork.Users.GetById(id);
            _unitOfWork.Users.Remove(user);
            _unitOfWork.Save();
        }
    }
}
