using LinkForwarding.Core.Core.Models.Entities;
using LinkForwarding.Core.DataAccess.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace LinkForwarding.Core.DataAccess.DataRepositories;

public class DataRepository : IDataRepository
{
    private readonly AppDataContext _appDataContext;

    public DataRepository(AppDataContext appDataContext)
    {
        _appDataContext = appDataContext;
    }

    public async ValueTask<IEnumerable<LinkPolicy>> GetAllLinkPolicies(int pageSize, int pageToken)
    {
        return await _appDataContext.LinkPolicies.Include(x => x.Links).Skip((pageToken - 1) * pageSize).Take(pageSize).ToListAsync();
    }
}