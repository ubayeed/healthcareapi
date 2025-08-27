namespace ClaraApi
{
    using Microsoft.Extensions.Caching.Memory;
    using System;

    public static class MemoryCacher
    {
        private static MemoryCache _cache = null;

        private static MemoryCache Cache
        {
            get {
                if (_cache == null)
                {
                    var options = new MemoryCacheOptions();
                    _cache = new MemoryCache(options);
                }
                return _cache;
            }
        }

        public static object? GetValue(string key)
        {
            Cache.TryGetValue(key, out object? result);
            return result;
        }

        public static object Add(string key, object value, DateTimeOffset absExpiration)
        {
            if (Cache.TryGetValue(key, out object? result))
                Cache.Remove(key);
            return Cache.Set(key, value, absExpiration);
        }

        public static void Delete(string key)
        {
            if (Cache.TryGetValue(key, out object? result))
                Cache.Remove(key);
        }
    }
}
