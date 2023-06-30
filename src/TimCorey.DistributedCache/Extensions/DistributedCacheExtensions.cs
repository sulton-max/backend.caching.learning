using System.Text.Json;
using DistributedCache.Models;
using DistributedCache.Query;
using Microsoft.Extensions.Caching.Distributed;

namespace DistributedCache.Extensions;

public static class DistributedCacheExtensions
{
    public static async Task SetEntryAsync<TEntry>(
        this IDistributedCache cache,
        TEntry entry,
        TimeSpan? absoluteExpirationTime = null,
        TimeSpan? slidingExpirationTime = null
    ) where TEntry : EntityBase
    {
        var options = new DistributedCacheEntryOptions();
        options.SetAbsoluteExpiration(absoluteExpirationTime ?? TimeSpan.FromSeconds(60));
        options.SetSlidingExpiration(slidingExpirationTime ?? TimeSpan.FromSeconds(30));

        var entryKey = new CacheKey(typeof(TEntry).Name, entry.Id).Key;
        var serializedData = JsonSerializer.Serialize(entry);
        await cache.SetStringAsync(entryKey, serializedData, options);
    }

    public static async Task<TEntry?> GetEntryAsync<TEntry>(this IDistributedCache cache, Guid entryId)
        where TEntry : EntityBase
    {
        var entryKey = new CacheKey(typeof(TEntry).Name, entryId).Key;
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
    ) where TEntry : EntityBase
    {
        var options = new DistributedCacheEntryOptions();
        options.SetAbsoluteExpiration(absoluteExpirationTime ?? TimeSpan.FromSeconds(60));
        options.SetSlidingExpiration(slidingExpirationTime ?? TimeSpan.FromSeconds(30));

        var entryKey = new CacheKey(typeof(TEntry).Name, pageSize, pageToken).Key;
        var serializedData = JsonSerializer.Serialize(entry);
        await cache.SetStringAsync(entryKey, serializedData, options);
    }

    public static async Task<IList<TEntry>?> GetEntryAsync<TEntry>(
        this IDistributedCache cache,
        int pageSize,
        int pageToken
    ) where TEntry : EntityBase
    {
        var entryKey = new CacheKey(typeof(TEntry).Name, pageSize, pageToken).Key;
        var cachedData = await cache.GetStringAsync(entryKey);
        return string.IsNullOrWhiteSpace(cachedData) ? default : JsonSerializer.Deserialize<List<TEntry>>(cachedData);
    }
}