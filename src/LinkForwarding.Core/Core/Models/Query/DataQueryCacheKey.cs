namespace LinkForwarding.Core.Core.Models.Query;

public class DataQueryCacheKey
{
    public string TypeName { get; }
    public int PageSiz { get; }
    public int PageToken { get; }

    public DataQueryCacheKey(string typeName, int pageSiz, int pageToken)
    {
        TypeName = typeName;
        PageSiz = pageSiz;
        PageToken = pageToken;
    }
}