using DeliveryService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Data
{
    public class Cache : ICache
    {
        private readonly Dictionary<object, object> _cache = new();
        private readonly object _locker = new();
        private readonly Dictionary<object, DateTime> _updateTime = new();
        private const int _invalidationTime = 5;

        public enum CollectionType
        {
            User,
            Product,
            Order
        }

        public object GetFromCache(object key, Func<object> addToCache)
        {
            lock (_locker)
            {
                if (_cache.ContainsKey(key) && _updateTime.ContainsKey(key))
                {
                    if ((DateTime.Now - _updateTime[key]).TotalMinutes > _invalidationTime)
                    {
                        _cache.Remove(key);
                        _updateTime.Remove(key);
                    }
                }
                if (!_cache.ContainsKey(key) && !_updateTime.ContainsKey(key))
                {
                    _cache[key] = addToCache();
                    _updateTime[key] = DateTime.Now;
                }
                return _cache[key];
            }
        }
    }
}
