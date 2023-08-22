using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QI.Core.Caching
{
    public class MemoryCachingService
    {
        private readonly IMemoryCache memoryCache;
        private static CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public MemoryCachingService(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        protected MemoryCacheEntryOptions GetMemoryCacheEntryOptions(int cacheTime = 60)
        {
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions()
                .AddExpirationToken(new CancellationChangeToken(_cancellationTokenSource.Token))
                .RegisterPostEvictionCallback(PostEviction);
            options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheTime);
            return options;
        }
        private void PostEviction(object key, object value, EvictionReason reason, object state)
        {
            if (reason == EvictionReason.Replaced)
            {
                return;
            }
            // TODO : some things
        }
        public T GetByKey<T>(string key)
        {
            return memoryCache.Get<T>(key);
        }
        public T GetOrCreate<T>(string key, Func<T> actionCallback)
        {

            return memoryCache.GetOrCreate(key, entry =>
            {
                return actionCallback();
            });
        }
        public T GetOrCreate<T>(string key, Func<T> actionCallback, int time)
        {
            return memoryCache.GetOrCreate(key, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(time);
                return actionCallback();
            });
        }
        public async Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> actionCallback, int time)
        {
            return await memoryCache.GetOrCreateAsync(key, async entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(time);
                return await actionCallback();
            });
        }

        public T SetValue<T>(string key, T value)
        {
            return memoryCache.Set(key, value, GetMemoryCacheEntryOptions());
        }

        public T SetValue<T>(string key, T value, int time)
        {
            return memoryCache.Set(key, value, GetMemoryCacheEntryOptions(time));
        }
    }
}
