using DistributedCache.Data;
using DistributedCache.Extensions;
using DistributedCache.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace DistributedCache.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly DataSource _dataSource;
    private readonly IDistributedCache _distributedCache;

    public UsersController(DataSource dataSource, IDistributedCache distributedCache)
    {
        _dataSource = dataSource;
        _distributedCache = distributedCache;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers([FromQuery] int pageSize, [FromQuery] int pageToken)
    {
        var users = await _distributedCache.GetEntryAsync<User>(pageSize, pageToken);
        if (!users?.Any() ?? true)
        {
            users = _dataSource.Users.Skip((pageToken - 1) * pageSize).Take(pageSize).ToList();
            await _distributedCache.SetEntryAsync(users, pageSize, pageToken);
        }

        return users?.Any() ?? false ? Ok(users) : NotFound();
    }
}