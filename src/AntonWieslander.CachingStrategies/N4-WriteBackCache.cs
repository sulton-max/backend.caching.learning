using Microsoft.Extensions.Caching.Distributed;

namespace AntonWieslander.CachingStrategies
{
    public class WriteBackCache : IDistributedCache
    {
        private readonly IDistributedCache primaryCache;
        private readonly IDistributedCache secondaryCache;
        private List<KeyValuePair<string, byte[]>> buffer;

        public WriteBackCache(IDistributedCache primaryCache, IDistributedCache secondaryCache)
        {
            this.primaryCache = primaryCache;
            this.secondaryCache = secondaryCache;
            buffer = new List<KeyValuePair<string, byte[]>>();
        }

        public byte[]? Get(string key)
        {


            throw new NotImplementedException();
        }

        public Task<byte[]?> GetAsync(string key, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public void Refresh(string key)
        {
            throw new NotImplementedException();
        }

        public Task RefreshAsync(string key, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string key, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
        {
            secondaryCache.Set(key, value, options);
            
            buffer.Add(new KeyValuePair<string, byte[]>(key, value));
        }

        public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task BatchUpdateAsync()
        {
            // Check if updates are more than 100 or just it has been 10 mins since the last write


        }
    }
}
