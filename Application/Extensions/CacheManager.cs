using System;
using System.Threading;
using Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace Application.Extensions
{
    public class CacheManager: ICacheManager
    {
        private static CancellationTokenSource resetCacheToken = null;
        private readonly IMemoryCache memoryCache;
        /// <summary>
        /// Cache Manager
        /// </summary>
        /// <param name="memoryCache"></param>
        public CacheManager(IMemoryCache memoryCache)
        {
            resetCacheToken = new CancellationTokenSource();
            this.memoryCache = memoryCache;
        }
        /// <summary>
        /// sets the cache entry T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expirationInMinutes"></param>
        /// <returns></returns>
        public T Set<T>(object key, T value, int expirationInMinutes = 60)
        {
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions().SetPriority(CacheItemPriority.Normal).SetAbsoluteExpiration(TimeSpan.FromMinutes(expirationInMinutes));
            options.AddExpirationToken(new CancellationChangeToken(resetCacheToken.Token));
            memoryCache.Set(key, value, options);
            return value;
        }
        /// <summary>
        /// checks for cache entry existence
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(object key)
        {
            return memoryCache.TryGetValue(key, out object result);
        }
        /// <summary>
        /// returns cache entry T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(object key)
        {
            return memoryCache.TryGetValue(key, out T result) ? result : default(T);
        }
        /// <summary>
        /// clear cache entry
        /// </summary>
        /// <param name="key"></param>
        public void Clear(object key)
        {
            memoryCache.Remove(key);
        }
        /// <summary>
        /// expires cache entries T based on CancellationTokenSource cancel 
        /// </summary>
        public void Reset()
        {
            if (resetCacheToken != null && !resetCacheToken.IsCancellationRequested &&
                resetCacheToken.Token.CanBeCanceled)
            {
                resetCacheToken.Cancel();
                resetCacheToken.Dispose();
            }
            resetCacheToken = new CancellationTokenSource();
        }
    }
}
