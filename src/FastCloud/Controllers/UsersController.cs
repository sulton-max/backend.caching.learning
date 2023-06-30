using FastCloud.Core.Models.Entities;
using FastCloud.DataAccess.DataContexts;
using FastCloud.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace FastCloud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDataContext _appDataContext;
    private readonly IDistributedCache _distributedCache;

    public UsersController(AppDataContext appDataContext, IDistributedCache distributedCache)
    {
        _appDataContext = appDataContext;
        _distributedCache = distributedCache;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers([FromQuery] int pageSize, [FromQuery] int pageToken)
    {
        var users = await _distributedCache.GetEntryAsync<User>(pageSize, pageToken);
        if (!users?.Any() ?? true)
        {
            users = await _appDataContext.Users.Include(x => x.Servers)
                .ThenInclude(x => x.Services)
                .Skip((pageToken - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            await _distributedCache.SetEntryAsync(users, pageSize, pageToken);
        }

        return users?.Any() ?? false ? Ok(users) : NotFound();
    }
}