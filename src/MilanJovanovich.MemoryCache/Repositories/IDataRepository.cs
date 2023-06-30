using MemoryCache.Models;

namespace MemoryCache.Repositories;

public interface IDataRepository
{
    ValueTask<IEnumerable<User>> GetAllUsersAsync(int pageSize, int pageToken);
}