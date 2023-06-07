using System.Text.Json;
using EasyTicket.DataAccess.DataContext;
using EasyTicket.Models.Entities;
using EasyTicket.Models.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace EasyTicket.Controllers;

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
    public async ValueTask<ActionResult<IEnumerable<User>>> GetUsers([FromQuery] int pageSize, [FromQuery] int pageToken)
    {
        var key = new CachedQueryKey(nameof(User), pageSize, pageToken);
        var serializedKey = JsonSerializer.Serialize(key);
        var users = await _memoryCache.GetOrCreateAsync(serializedKey,
            async entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(2);
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
                return await _appDataContext.Users.Include(x => x.Tickets).Skip((pageToken - 1) * pageSize).Take(pageSize).ToListAsync();
            });
        users ??= new List<User>();
        return users?.Any() ?? false ? Ok(users) : NotFound();
    }
}