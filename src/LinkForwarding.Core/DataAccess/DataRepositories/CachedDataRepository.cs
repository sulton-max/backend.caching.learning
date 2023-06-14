using System.Text.Json;
using LinkForwarding.Core.Core.Models.Entities;
using LinkForwarding.Core.Core.Models.Query;
using Microsoft.Extensions.Caching.Distributed;

namespace LinkForwarding.Core.DataAccess.DataRepositories;

public class CachedDataRepository : IDataRepository
{
    private readonly IDataRepository _dataRepository;
    private readonly IDistributedCache _distributedCache;

    public CachedDataRepository(IDataRepository dataRepository, IDistributedCache distributedCache)
    {
        _dataRepository = dataRepository;
        _distributedCache = distributedCache;
    }

    public async ValueTask<IEnumerable<LinkPolicy>> GetAllLinkPolicies(int pageSize, int pageToken)
    {
        var key = new DataQueryCacheKey(nameof(LinkPolicy), pageSize, pageToken);
        var keyString = JsonSerializer.Serialize(key);
        var cachedData = await _distributedCache.GetStringAsync(keyString);
        List<LinkPolicy>? linkPolicies;

        if (string.IsNullOrWhiteSpace(cachedData))
        {
            linkPolicies = (await _dataRepository.GetAllLinkPolicies(pageSize, pageToken)).ToList();
            if (linkPolicies?.Any() ?? false)
                await _distributedCache.SetStringAsync(keyString, JsonSerializer.Serialize(linkPolicies));
        }
        else
            linkPolicies = JsonSerializer.Deserialize<IEnumerable<LinkPolicy>>(cachedData)?.ToList();

        return linkPolicies ?? new List<LinkPolicy>();
    }
}