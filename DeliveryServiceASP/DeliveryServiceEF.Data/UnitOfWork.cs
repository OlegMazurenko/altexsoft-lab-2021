using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryServiceEF.Domain.Interfaces;

namespace DeliveryServiceEF.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public ICategoryRepository Categories { get; }
        public IOrderRepository Orders { get; }
        public IProductRepository Products { get; }
        public IUserRepository Users { get; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Categories = new CategoryRepository(_context);
            Orders = new OrderRepository(_context);
            Products = new ProductRepository(_context);
            Users = new UserRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
