using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.Interfaces;

namespace DeliveryService
{
    public class Logger : ILogger
    {
        public void Log(string text)
        {
            text = $"{DateTime.Now} {text}";
            var fileName = DateTime.Now.ToString("dd-MM-yyyy") + "_log.txt";
            using var file = new FileStream(fileName, FileMode.Append);
            using var stream = new StreamWriter(file, Encoding.UTF8);
            stream.WriteLine(text);
        }
    }
}
