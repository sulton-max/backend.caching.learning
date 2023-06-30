namespace DistributedCache.Core.Query;

public class CacheKey
{
    public string TypeName { get; }
    public int PageSize { get; }
    public int PageToken { get; }

    public CacheKey(string typeName, int pageSize, int pageToken)
    {
        TypeName = typeName;
        PageSize = pageSize;
        PageToken = pageToken;
    }
}