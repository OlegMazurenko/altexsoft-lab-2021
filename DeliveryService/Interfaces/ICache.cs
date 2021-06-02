using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface ICache
    {
        object GetFromCache(object key, Func<object> addToCache);
    }
}
