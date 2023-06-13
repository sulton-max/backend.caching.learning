namespace PowerFitness.Core.Models.Query;

public class DataQueryCacheKey
{
    public readonly string TypeName;
    public readonly int PageSize;
    public readonly int PageToken;

    public DataQueryCacheKey(string typeName, int pageSize, int pageToken)
    {
        TypeName = typeName;
        PageSize = pageSize;
        PageToken = pageToken;
    }
}