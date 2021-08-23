using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        public T GetById(int id);
        IEnumerable<T> GetAll();
        void Remove(T item);
        void Update(T item);
    }
}
