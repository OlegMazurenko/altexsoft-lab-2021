﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DeliveryServiceEF.Data;
using DeliveryServiceEF.Domain.Controllers;
using DeliveryServiceEF.Domain.Interfaces;
using DeliveryServiceEF.Domain.Models;

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
            services.AddScoped<CategoryController>();
            services.AddScoped<OrderController>();
            services.AddScoped<ProductController>();
            services.AddScoped<UserController>();
            return services;
        }
    }
}
