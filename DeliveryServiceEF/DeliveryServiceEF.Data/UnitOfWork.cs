using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryServiceEF.Domain.Interfaces;
using DeliveryServiceEF.Domain.Models;

namespace DeliveryServiceEF.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IRepository<Category> _categories;
        private IRepository<Order> _orders;
        private IRepository<Product> _products;
        private IRepository<User> _users;

        public IRepository<Category> Categories { get => _categories ??= new Repository<Category>(_context); }
        public IRepository<Order> Orders { get => _orders ??= new Repository<Order>(_context); }
        public IRepository<Product> Products { get => _products ??= new Repository<Product>(_context); }
        public IRepository<User> Users { get => _users ??= new Repository<User>(_context); }

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
