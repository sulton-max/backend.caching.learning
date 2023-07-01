using AppLevelCache.OutputCache.Redis.Models;
using Tynamix.ObjectFiller;

namespace AppLevelCache.OutputCache.Redis.Data;

public class DataSource
{
    private static readonly List<User> UsersData = new Filler<User>().Create(100000).ToList();

    public List<User> Users
    {
        get
        {
            // When using database delay of between 50~150ms is guaranteed
            Thread.Sleep(50);
            return UsersData;
        }
    }
}