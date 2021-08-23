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
        public IRepository<Category> Categories { get; }
        public IRepository<Order> Orders { get; }
        public IRepository<Product> Products { get; }
        public IRepository<User> Users { get; }

        public UnitOfWork(DataContext context, IRepository<Category> categories, IRepository<Order> orders, 
            IRepository<Product> products, IRepository<User> users)
        {
            _context = context;
            Categories = categories;
            Orders = orders;
            Products = products;
            Users = users;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
