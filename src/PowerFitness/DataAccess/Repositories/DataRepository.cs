using Microsoft.EntityFrameworkCore;
using PowerFitness.Core.Models.Entities;
using PowerFitness.DataAccess.DataContext;

namespace PowerFitness.DataAccess.Repositories;

public class DataRepository : IDataRepository
{
    private readonly AppDataContext _appDataContext;

    public DataRepository(AppDataContext appDataContext)
    {
        _appDataContext = appDataContext;
    }

    public async ValueTask<IEnumerable<User>> GetAllUsers(int pageSize, int pageToken)
    {
        return await _appDataContext.Users.Include(user => user.Subscription).Skip((pageToken - 1) * pageSize).Take(pageSize).ToListAsync();
    }
}