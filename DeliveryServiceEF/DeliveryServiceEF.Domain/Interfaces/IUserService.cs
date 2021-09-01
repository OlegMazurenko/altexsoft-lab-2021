using DeliveryServiceEF.Domain.Models;
using System.Collections.Generic;

namespace DeliveryServiceEF.Domain.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        void DeleteUser(int id);
        User GetUser(int id);
        IEnumerable<User> GetUsers();
    }
}