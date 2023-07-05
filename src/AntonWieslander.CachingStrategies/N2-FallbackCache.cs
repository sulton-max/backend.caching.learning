using Microsoft.Extensions.Caching.Distributed;

namespace AntonWieslander.CachingStrategies
{
    public class FallBackCache : IDistributedCache
    {
        private readonly IDistributedCache primaryCache;
        private readonly IDistributedCache secondaryCache;

        public FallBackCache(IDistributedCache primaryCache, IDistributedCache secondaryCache)
        {
            this.primaryCache = primaryCache;
            this.secondaryCache = secondaryCache;
        }

        public byte[]? Get(string key)
        {
            try
            {
                return primaryCache.Get(key);
            }
            catch (Exception)
            {
                // log and process
            }

            return secondaryCache.Get(key);
        }

        public Task<byte[]?> GetAsync(string key, CancellationToken token = default)
        {
            try
            {
                return primaryCache.GetAsync(key, token);
            }
            catch (Exception)
            {
                // log and process
            }

            return secondaryCache.GetAsync(key, token);
        }

        public void Refresh(string key)
        {
            try
            {
                primaryCache.Refresh(key);
            }
            catch (Exception)
            {
                // log and process
            }

            secondaryCache.Refresh(key);
        }

        public Task RefreshAsync(string key, CancellationToken token = default)
        {
            try
            {
                return primaryCache.RefreshAsync(key, token);
            }
            catch (Exception)
            {
                // log and process
            }

            return secondaryCache.RefreshAsync(key, token);
        }

        public void Remove(string key)
        {
            try
            {
                primaryCache.Remove(key);
            }
            catch (Exception)
            {
                // log and process
            }

            secondaryCache.Remove(key);
        }

        public Task RemoveAsync(string key, CancellationToken token = default)
        {
            try
            {
                return primaryCache.RemoveAsync(key, token);
            }
            catch (Exception)
            {
                // log and process
            }

            return secondaryCache.RemoveAsync(key, token);
        }

        public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
        {
            try
            {
                primaryCache.Set(key, value, options);
            }
            catch (Exception)
            {
                // log and process
            }

            secondaryCache.Set(key, value, options);
        }

        public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default)
        {
            try
            {
                return primaryCache.SetAsync(key, value, options, token);
            }
            catch (Exception)
            {
                // log and process
            }

            return secondaryCache.SetAsync(key, value, options, token);
        }
    }
}
