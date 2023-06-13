using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using PowerFitness.Core.Models.Entities;
using PowerFitness.Core.Models.Query;

namespace PowerFitness.DataAccess.Repositories;

public class CachedDataRepository : IDataRepository
{
    private readonly IDataRepository _dataRepository;
    private readonly IMemoryCache _memoryCache;

    public CachedDataRepository(IDataRepository dataRepository, IMemoryCache memoryCache)
    {
        _dataRepository = dataRepository;
        _memoryCache = memoryCache;
    }

    public async ValueTask<IEnumerable<User>> GetAllUsers(int pageSize, int pageToken)
    {
        var key = new DataQueryCacheKey(nameof(User), pageSize, pageToken);
        var keyString = JsonSerializer.Serialize(key);
        var users = await _memoryCache.GetOrCreateAsync(keyString, async entry => await _dataRepository.GetAllUsers(pageSize, pageToken));
        return users ?? new List<User>();
    }
}