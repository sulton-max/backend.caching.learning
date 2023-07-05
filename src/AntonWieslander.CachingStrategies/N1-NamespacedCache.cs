using Microsoft.Extensions.Caching.Distributed;

namespace AntonWieslander.CachingStrategies;

public class NamespacedCache : IDistributedCache
{
    private readonly IDistributedCache _distributedCache;
    private readonly string _name;

    public NamespacedCache(IDistributedCache distributedCache, string name)
    {
        _distributedCache = distributedCache;
        _name = name;
    }

    public byte[]? Get(string key) => _distributedCache.Get(key);

    public Task<byte[]?> GetAsync(string key, CancellationToken token = new CancellationToken()) =>
        _distributedCache.GetAsync(key, token);

    public void Set(string key, byte[] value, DistributedCacheEntryOptions options) =>
        _distributedCache.SetAsync(key, value);

    public Task SetAsync(
        string key,
        byte[] value,
        DistributedCacheEntryOptions options,
        CancellationToken token = new CancellationToken()
    ) =>
        _distributedCache.SetAsync(key, value, options, token);

    public void Refresh(string key) => _distributedCache.Refresh(key);

    public Task RefreshAsync(string key, CancellationToken token = new CancellationToken()) =>
        _distributedCache.RefreshAsync(key, token);

    public void Remove(string key) => _distributedCache.Remove(key);

    public Task RemoveAsync(string key, CancellationToken token = new CancellationToken()) =>
        _distributedCache.RemoveAsync(key, token);
}