using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using UniBlog.Core.Models.Entity;
using UniBlog.Core.Models.Query;
using UniBlog.DataAccess.DataContext;

namespace UniBlog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDataContext _appDataContext;
    private readonly IMemoryCache _memoryCache;

    public UsersController(AppDataContext appDataContext, IMemoryCache memoryCache)
    {
        _appDataContext = appDataContext;
        _memoryCache = memoryCache;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers([FromQuery] int pageSize, [FromQuery] int pageToken)
    {
        var key = new CachedDataQueryKey(nameof(User), pageSize, pageToken);
        var serializedKey = JsonSerializer.Serialize(key);

        var users = _memoryCache.Get<IEnumerable<User>>(serializedKey)?.ToList();
        if (!users?.Any() ?? true)
        {
            users = await _appDataContext.Users.Include(user => user.Posts).Skip((pageToken - 1) * pageSize).Take(pageSize).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetPriority(CacheItemPriority.Normal)
                .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

            _memoryCache.Set(serializedKey, users, cacheEntryOptions);
        }

        return users?.Any() ?? false ? Ok(users) : NotFound();
    }
}