using System.Diagnostics;
using AppLevelCache.OutputCache.Redis.Data;
using AppLevelCache.OutputCache.Redis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace AppLevelCache.OutputCache.Redis.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IOutputCacheStore _outputCacheStore;
    private readonly DataSource _dataSource;

    public UsersController(DataSource dataSource, IOutputCacheStore outputCacheStore)
    {
        _outputCacheStore = outputCacheStore;
        _dataSource = dataSource;
    }

    [HttpGet]
    [Tags("Users")]
    [OutputCache]
    public IActionResult GetAll()
    {
        var users = _dataSource.Users;
        return Ok(users);
    }

    [HttpGet("{id:Guid}")]
    [Tags("User")]
    [OutputCache]
    public IActionResult Get([FromRoute] Guid id, CancellationToken ct)
    {
        var user = _dataSource.Users.Find(x => x.Id == id);
        return Ok(user);
    }

    [HttpPost]
    [Tags("Users", "User")]
    public IActionResult Post([FromBody] User user, CancellationToken ct)
    {
        user.Id = Guid.NewGuid();
        _dataSource.Users.Add(user);
        _outputCacheStore.EvictByTagAsync(nameof(User), ct);

        return Created(Url.Action(nameof(Get),
                new
                {
                    id = user.Id
                })!,
            user);
    }

    [HttpPut]
    [Tags("Users", "User")]
    public IActionResult Put([FromBody] User user, CancellationToken ct)
    {
        user.Id = Guid.NewGuid();
        _dataSource.Users.Add(user);
        _outputCacheStore.EvictByTagAsync(user.Id.ToString(), ct);
        _outputCacheStore.EvictByTagAsync(nameof(User), ct);

        return NoContent();
    }

    [HttpDelete("{id:Guid}")]
    [Tags("Users", "User")]
    public IActionResult Delete([FromRoute] Guid id, CancellationToken ct)
    {
        _dataSource.Users.RemoveAll(x => x.Id == id);
        _outputCacheStore.EvictByTagAsync(id.ToString(), ct);
        _outputCacheStore.EvictByTagAsync(nameof(User), ct);

        return NoContent();
    }
}