using System.Text.Json;
using FastCloud.Core.Models.Entities;
using FastCloud.Core.Models.Query;
using Microsoft.Extensions.Caching.Distributed;

namespace FastCloud.Extensions;

public static class DistributedCacheExtensions
{
    public static async Task SetEntryAsync<TEntry>(
        this IDistributedCache cache,
        TEntry entry,
        TimeSpan? absoluteExpirationTime = null,
        TimeSpan? slidingExpirationTime = null
    ) where TEntry : IEntity
    {
        var options = new DistributedCacheEntryOptions();
        options.SetAbsoluteExpiration(absoluteExpirationTime ?? TimeSpan.FromSeconds(60));
        options.SetSlidingExpiration(slidingExpirationTime ?? TimeSpan.FromSeconds(30));

        var entryKey = new DataQueryCacheKey(typeof(TEntry).Name, entry.Id).Key();
        var serializedData = JsonSerializer.Serialize(entry);
        await cache.SetStringAsync(entryKey, serializedData, options);
    }

    public static async Task<TEntry?> GetEntryAsync<TEntry>(this IDistributedCache cache, Guid entryId) where TEntry : IEntity
    {
        var entryKey = new DataQueryCacheKey(typeof(TEntry).Name, entryId).Key();
        var cachedData = await cache.GetStringAsync(entryKey);
        return string.IsNullOrWhiteSpace(cachedData) ? default : JsonSerializer.Deserialize<TEntry>(cachedData);
    }

    public static async Task SetEntryAsync<TEntry>(
        this IDistributedCache cache,
        IEnumerable<TEntry> entry,
        int pageSize,
        int pageToken,
        TimeSpan? absoluteExpirationTime = null,
        TimeSpan? slidingExpirationTime = null
    ) where TEntry : IEntity
    {
        var options = new DistributedCacheEntryOptions();
        options.SetAbsoluteExpiration(absoluteExpirationTime ?? TimeSpan.FromSeconds(60));
        options.SetSlidingExpiration(slidingExpirationTime ?? TimeSpan.FromSeconds(30));

        var entryKey = new DataQueryCacheKey(typeof(TEntry).Name, pageSize, pageToken).Key();
        var serializedData = JsonSerializer.Serialize(entry);
        await cache.SetStringAsync(entryKey, serializedData, options);
    }

    public static async Task<IList<TEntry>?> GetEntryAsync<TEntry>(this IDistributedCache cache, int pageSize, int pageToken) where TEntry : IEntity
    {
        var entryKey = new DataQueryCacheKey(typeof(TEntry).Name, pageSize, pageToken).Key();
        var cachedData = await cache.GetStringAsync(entryKey);
        return string.IsNullOrWhiteSpace(cachedData) ? default : JsonSerializer.Deserialize<List<TEntry>>(cachedData);
    }
}