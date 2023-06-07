namespace EasyTicket.Models.Query;

public class CachedQueryKey
{
    private readonly int _pageToken;
    public string TypeName { get; }
    public int PageSize { get; }

    public CachedQueryKey(string typeName, int pageSize, int pageToken)
    {
        _pageToken = pageToken;
        TypeName = typeName;
        PageSize = pageSize;
    }
}