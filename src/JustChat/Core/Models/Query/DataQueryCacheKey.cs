namespace JustChat.Core.Models.Query;

public class DataQueryCacheKey
{
    public string TypeName { get; }
    public int PageSize { get; }
    public int PageToken { get; }

    public DataQueryCacheKey(string typeName, int pageSize, int pageToken)
    {
        TypeName = typeName;
        PageSize = pageSize;
        PageToken = pageToken;
    }
}