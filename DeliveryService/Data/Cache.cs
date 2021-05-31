using DeliveryService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Data
{
    public class Cache : ICache
    {
        private readonly Dictionary<CollectionType, object> _cache = new Dictionary<CollectionType, object>();
        private readonly object _locker = new();
        private DateTime _updateTime = new();

        public enum CollectionType
        {
            User,
            Product,
            Order
        }

        public object GetFromCache(int key, Func<object> addToCache)
        {
            lock (_locker)
            {
                if ((DateTime.Now - _updateTime).TotalMinutes > 5)
                {
                    _cache.Clear();
                }
                if (!_cache.ContainsKey((CollectionType)key))
                {
                    _cache[(CollectionType)key] = addToCache();
                    _updateTime = DateTime.Now;
                }
                return _cache[(CollectionType)key];
            }
        }
    }
}
