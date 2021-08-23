using DeliveryServiceEF.Data;
using System;

namespace DeliveryServiceEF.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new DataContext();
            context.Database.EnsureCreated();
            var unitOfWork = new UnitOfWork(context);
        }
    }
}
