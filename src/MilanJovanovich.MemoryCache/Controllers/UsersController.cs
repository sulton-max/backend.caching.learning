using MemoryCache.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MemoryCache.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IDataRepository _dataRepository;

    public UsersController(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers(int pageSize, int pageToken)
    {
        var users = await _dataRepository.GetAllUsersAsync(pageSize, pageToken);
        return users.Any() ? Ok(users) : NotFound();
    }
}