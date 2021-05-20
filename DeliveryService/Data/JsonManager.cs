using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using DeliveryService.Interfaces;

namespace DeliveryService.Data
{
    public class JsonManager : IFileManager
    {
        public void SaveToFile<T>(IList<T> list, string fileName) where T : class
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(fileName, JsonSerializer.Serialize(list, options), Encoding.Unicode);
        }
        public IList<T> LoadFromFile<T>(string fileName) where T : class
        {
            return File.Exists(fileName) ? JsonSerializer.Deserialize<List<T>>(File.ReadAllText(fileName, Encoding.Unicode)) : new List<T>();
        }
    }
}
