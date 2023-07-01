using AppLevelCache.OutputCache.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace AppLevelCache.OutputCache.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly DataSource _dataSource;

    public UsersController(DataSource dataSource)
    {
        _dataSource = dataSource;
    }

    [HttpGet]
    [OutputCache(Duration = 10000)]
    public async Task<IActionResult> GetAllUsers([FromQuery] int pageSize, [FromQuery] int pageToken)
    {
        var users = await Task.Run(() => _dataSource.Users.Skip((pageToken - 1) * pageSize).Take(pageSize).ToList());
        return users?.Any() ?? false ? Ok(users) : NotFound();
    }
}