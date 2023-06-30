using System.Text.Json;
using MemoryCache.Models;
using MemoryCache.Query;
using Microsoft.Extensions.Caching.Memory;

namespace MemoryCache.Repositories;

public class CachedDataRepository : IDataRepository
{
    private readonly IDataRepository _dataRepository;
    private readonly IMemoryCache _memoryCache;

    public CachedDataRepository(IDataRepository dataRepository, IMemoryCache memoryCache)
    {
        _dataRepository = dataRepository;
        _memoryCache = memoryCache;
    }

    public async ValueTask<IEnumerable<User>> GetAllUsersAsync(int pageSize, int pageToken)
    {
        var key = new CacheKey(nameof(User), pageSize, pageToken);
        var keyString = JsonSerializer.Serialize(key);
        var users = await _memoryCache.GetOrCreateAsync(keyString, async entry => await _dataRepository.GetAllUsersAsync(pageSize, pageToken));
        return users ?? new List<User>();
    }
}