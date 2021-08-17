using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryServiceEF.Domain.Interfaces;
using DeliveryServiceEF.Domain.Models;

namespace DeliveryServiceEF.Data
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context) { }
    }
}
