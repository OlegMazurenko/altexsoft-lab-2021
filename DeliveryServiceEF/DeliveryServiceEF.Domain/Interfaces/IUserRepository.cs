using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryServiceEF.Domain.Models;

namespace DeliveryServiceEF.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
