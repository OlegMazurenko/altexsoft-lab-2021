using DeliveryServiceEF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Domain.Controllers
{
    public class UserController
    {
        private IUnitOfWork UnitOfWork { get; }

        public UserController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
