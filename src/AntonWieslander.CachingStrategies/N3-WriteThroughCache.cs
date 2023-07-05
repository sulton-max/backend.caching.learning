using Microsoft.Extensions.Caching.Distributed;

namespace AntonWieslander.CachingStrategies
{
    public class WriteThroughCache : IDistributedCache
    {
        private readonly IDistributedCache primaryCache;
        private readonly IDistributedCache secondaryCache;

        public WriteThroughCache(IDistributedCache primaryCache, IDistributedCache secondaryCache)
        {
            this.primaryCache = primaryCache;      // distributed cache
            this.secondaryCache = secondaryCache;  // local cache
        }

        public byte[]? Get(string key)
        {
            var entry = secondaryCache.Get(key);
            if (entry == null)
            {
                entry = primaryCache.Get(key);

                if (entry != null)
                    secondaryCache.Set(key, entry);
            }

            return entry;
        }

        public async Task<byte[]?> GetAsync(string key, CancellationToken token = default)
        {
            var entry = await secondaryCache.GetAsync(key, token);
            if (entry == null)
            {
                entry = await primaryCache.GetAsync(key, token);

                if (entry != null)
                    await secondaryCache.SetAsync(key, entry, token);
            }

            return entry;
        }

        public void Refresh(string key)
        {
            secondaryCache.Refresh(key);
            primaryCache.Refresh(key);
        }

        public async Task RefreshAsync(string key, CancellationToken token = default)
        {
            await secondaryCache.RefreshAsync(key, token);
            await primaryCache.RefreshAsync(key, token);
        }

        public void Remove(string key)
        {
            secondaryCache.Remove(key);
            primaryCache.Remove(key);
        }

        public async Task RemoveAsync(string key, CancellationToken token = default)
        {
            await secondaryCache.RemoveAsync(key, token);
            await primaryCache.RemoveAsync(key, token);
        }

        public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
        {
            secondaryCache.Set(key, value, options);
            primaryCache.Set(key, value, options);
        }

        public async Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default)
        {
            await secondaryCache.SetAsync(key, value, options, token);
            await primaryCache.SetAsync(key, value, options, token);
        }
    }
}
