using DeliveryServiceEF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Domain.Controllers
{
    public class ProductController
    {
        private IUnitOfWork UnitOfWork { get; }

        public ProductController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
