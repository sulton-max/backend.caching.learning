using System.Text.Json;

namespace DistributedCache.Query;

public class CacheKey
{
    private Guid? Id { get; }
    private string? TypeName { get; }
    private int? PageSize { get; }
    private int? PageToken { get; }

    public CacheKey(string typeName, Guid id)
    {
        TypeName = typeName;
        Id = id;
        PageSize = default;
        PageToken = default;
    }

    public CacheKey(string typeName, int pageSize, int pageToken)
    {
        TypeName = typeName;
        PageSize = pageSize;
        PageToken = pageToken;
        Id = default;
    }

    public string Key
    {
        get
        {
            if (Id is not null)
                return JsonSerializer.Serialize(new
                {
                    TypeName,
                    Id
                });

            return JsonSerializer.Serialize(new
            {
                TypeName,
                PageSize,
                PageToken
            });
        }
    }
}