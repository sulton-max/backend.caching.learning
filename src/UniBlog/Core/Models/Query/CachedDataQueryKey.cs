namespace UniBlog.Core.Models.Query;

public class CachedDataQueryKey
{
    public string TypeName { get; }
    public int PageSize { get; }
    public int PageToken { get; }

    public CachedDataQueryKey(string typeName, int pageSize, int pageToken)
    {
        TypeName = typeName;
        PageSize = pageSize;
        PageToken = pageToken;
    }
}