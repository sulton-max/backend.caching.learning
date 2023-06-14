using LinkForwarding.Core.Core.Models.Entities;

namespace LinkForwarding.Core.DataAccess.DataRepositories;

public interface IDataRepository
{
    ValueTask<IEnumerable<LinkPolicy>> GetAllLinkPolicies(int pageSize, int pageToken);
}