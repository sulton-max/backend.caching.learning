using System.Text.Json;
using JustChat.Core.Models.Entities;
using JustChat.Core.Models.Query;
using JustChat.DataAccess.DataContext;
using LazyCache;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace JustChat.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupsController : ControllerBase
{
    private readonly AppDataContext _appDataContext;
    private readonly IAppCache _appCache;

    public GroupsController(AppDataContext appDataContext, IAppCache appCache)
    {
        _appDataContext = appDataContext;
        _appCache = appCache;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GroupChat>>> GetAllGroups([FromQuery] int pageSize, [FromQuery] int pageToken)
    {
        var key = new DataQueryCacheKey(nameof(GroupChat), pageSize, pageToken);
        var serializedKey = JsonSerializer.Serialize(key);
        var groups = await _appCache.GetOrAddAsync(serializedKey,
            async entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
                entry.SetSlidingExpiration(TimeSpan.FromMinutes(1));
                return await _appDataContext.Groups.Include(x => x.Announcements).Skip((pageToken - 1) * pageSize).Take(pageSize).ToListAsync();
            });

        return groups?.Any() ?? false ? Ok(groups) : NotFound();
    }
}