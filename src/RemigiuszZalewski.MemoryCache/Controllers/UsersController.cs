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
    public async ValueTask<ActionResult<IEnumerable<User>>> GetUsers([FromQuery] int pageSize, [FromQuery] int pageToken)
    {
        var key = new CacheKey(nameof(User), pageSize, pageToken);
        var serializedKey = JsonSerializer.Serialize(key);
        var users = await _memoryCache.GetOrCreateAsync(serializedKey,
            async entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(2);
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
                return await Task.Run(() => _dataSource.Users.Skip((pageToken - 1) * pageSize).Take(pageSize).ToList());
            });
        users ??= new List<User>();
        return users?.Any() ?? false ? Ok(users) : NotFound();
    }
}