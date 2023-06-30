using System.Text.Json;
using LazyCache;
using MemoryCache.LazyCache.Data;
using MemoryCache.LazyCache.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MemoryCache.LazyCache.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly DataSource _dataSource;
    private readonly IAppCache _appCache;

    public UsersController(DataSource dataSource, IAppCache appCache)
    {
        _dataSource = dataSource;
        _appCache = appCache;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers([FromQuery] int pageSize, [FromQuery] int pageToken)
    {
        var key = new CacheKey(nameof(User), pageSize, pageToken);
        var serializedKey = JsonSerializer.Serialize(key);
        var users = await _appCache.GetOrAddAsync(serializedKey,
            async entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
                entry.SetSlidingExpiration(TimeSpan.FromMinutes(1));
                return await Task.Run(() => _dataSource.Users.Skip((pageToken - 1) * pageSize).Take(pageSize).ToList());
            });

        return users?.Any() ?? false ? Ok(users) : NotFound();
    }
}