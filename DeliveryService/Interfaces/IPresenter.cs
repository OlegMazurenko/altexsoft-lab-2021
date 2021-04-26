using DeliveryService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface IPresenter
    {
        void ShowMenu(IProductController productController);
    }
}
