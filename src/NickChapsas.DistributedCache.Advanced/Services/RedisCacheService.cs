using StackExchange.Redis;

namespace NickChapsas.DistributedCache.Advanced.Services;

public class RedisCacheService : ICacheService
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
    }

    public async Task<string?> GetCacheValueAsync(string key)
    {
        var db = _connectionMultiplexer.GetDatabase();
        return await db.StringGetAsync(key);
    }

    public Task SetCacheValueAsync(string key, string value)
    {
        var db = _connectionMultiplexer.GetDatabase();
        return db.StringSetAsync(key, value);
    }
}