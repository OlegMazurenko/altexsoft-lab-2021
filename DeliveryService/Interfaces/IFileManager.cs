using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Interfaces
{
    public interface IFileManager
    {
        void SaveToFile<T>(IList<T> list, string fileName) where T : class;
        IList<T> LoadFromFile<T>(string fileName) where T : class;
    }
}
