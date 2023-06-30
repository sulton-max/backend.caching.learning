using System.Text.Json;
using DistributedCache.Core.Models;
using DistributedCache.Core.Query;
using Microsoft.Extensions.Caching.Distributed;

namespace DistributedCache.Core.Repositories;

public class CachedDataRepository : IDataRepository
{
    private readonly IDataRepository _dataRepository;
    private readonly IDistributedCache _distributedCache;

    public CachedDataRepository(IDataRepository dataRepository, IDistributedCache distributedCache)
    {
        _dataRepository = dataRepository;
        _distributedCache = distributedCache;
    }

    public async ValueTask<IEnumerable<User>> GetAllUsersAsync(int pageSize, int pageToken)
    {
        var key = new CacheKey(nameof(User), pageSize, pageToken);
        var keyString = JsonSerializer.Serialize(key);
        var cachedData = await _distributedCache.GetStringAsync(keyString);
        List<User>? users;

        if (string.IsNullOrWhiteSpace(cachedData))
        {
            users = (await _dataRepository.GetAllUsersAsync(pageSize, pageToken)).ToList();
            if (users?.Any() ?? false)
                await _distributedCache.SetStringAsync(keyString, JsonSerializer.Serialize(users));
        }
        else
            users = JsonSerializer.Deserialize<IEnumerable<User>>(cachedData)?.ToList();

        return users ?? new List<User>();
    }
}