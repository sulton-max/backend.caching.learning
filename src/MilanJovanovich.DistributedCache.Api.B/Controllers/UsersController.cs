using DistributedCache.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DistributedCache.Api.B.Controllers;

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
    public async Task<IActionResult> GetAllUsers([FromQuery] int pageSize, [FromQuery] int pageToken)
    {
        var linkPolicies = await _dataRepository.GetAllUsersAsync(pageSize, pageToken);
        return linkPolicies.Any() ? Ok(linkPolicies) : NotFound();
    }
}