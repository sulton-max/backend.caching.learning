using MemoryCache.Data;
using MemoryCache.Models;

namespace MemoryCache.Repositories;

public class DataRepository : IDataRepository
{
    private readonly DataSource _dataSource;

    public DataRepository(DataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public ValueTask<IEnumerable<User>> GetAllUsersAsync(int pageSize, int pageToken)
    {
        return new ValueTask<IEnumerable<User>>(Task.Run(() =>
            _dataSource.Users.Skip((pageToken - 1) * pageSize).Take(pageSize).ToList().AsEnumerable()));
    }
}