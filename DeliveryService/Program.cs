using System;
using System.Collections.Generic;
using DeliveryService.Controllers;
using DeliveryService.Models;

namespace DeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            menu.ShowMenu();
        }
    }
}
