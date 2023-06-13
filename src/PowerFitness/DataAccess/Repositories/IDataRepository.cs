using PowerFitness.Core.Models.Entities;

namespace PowerFitness.DataAccess.Repositories;

public interface IDataRepository
{
    ValueTask<IEnumerable<User>> GetAllUsers(int pageSize, int pageToken);
}