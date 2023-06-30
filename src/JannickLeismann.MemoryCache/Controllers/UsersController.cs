using System.Text.Json;
using MemoryCache.Data;
using MemoryCache.Models;
using MemoryCache.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MemoryCache.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly DataSource _dataSource;
    private readonly IMemoryCache _memoryCache;

    public UsersController(DataSource dataSource, IMemoryCache memoryCache)
    {
        _dataSource = dataSource;
        _memoryCache = memoryCache;
    }

    [HttpGet]
    public IActionResult GetUsers([FromQuery] int pageSize, [FromQuery] int pageToken)
    {
        var key = new CacheKey(nameof(User), pageSize, pageToken);
        var serializedKey = JsonSerializer.Serialize(key);

        var users = _memoryCache.Get<IEnumerable<User>>(serializedKey)?.ToList();
        if (!users?.Any() ?? true)
        {
            users = _dataSource.Users.Skip((pageToken - 1) * pageSize).Take(pageSize).ToList();
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetPriority(CacheItemPriority.Normal)
                .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

            _memoryCache.Set(serializedKey, users, cacheEntryOptions);
        }

        return users?.Any() ?? false ? Ok(users) : NotFound();
    }
}