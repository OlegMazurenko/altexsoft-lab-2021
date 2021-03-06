using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DeliveryServiceEF.Data;
using DeliveryServiceEF.Domain.Services;
using DeliveryServiceEF.Domain.Interfaces;
using DeliveryServiceEF.Domain.Models;
using DeliveryServiceEF.Web.Filters;
using Microsoft.Extensions.Logging;

namespace DeliveryServiceEF.Web
{
    public static class ServicesContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<Category>, Repository<Category>>();
            services.AddScoped<IRepository<Order>, Repository<Order>>();
            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ProductActionFilter>();
            services.AddScoped<ProductExeptionFilter>();
            services.AddScoped<ILogger, Logger<ProductExeptionFilter>>();
            return services;
        }
    }
}
