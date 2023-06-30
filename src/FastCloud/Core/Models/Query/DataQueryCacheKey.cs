using System.Text.Json;

namespace FastCloud.Core.Models.Query;

public class DataQueryCacheKey
{
    private string TypeName { get; }
    private Guid Id { get; }
    private int PageSize { get; }
    private int PageToken { get; }

    public DataQueryCacheKey(string typeName, Guid id)
    {
        TypeName = typeName;
        Id = id;
    }

    public DataQueryCacheKey(string typeName, int pageSize, int pageToken)
    {
        TypeName = typeName;
        PageSize = pageSize;
        PageToken = pageToken;
    }

    public string Key()
    {
        if (Id != Guid.Empty)
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