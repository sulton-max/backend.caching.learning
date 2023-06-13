using Microsoft.AspNetCore.Mvc;
using PowerFitness.Core.Models.Entities;
using PowerFitness.DataAccess.Repositories;

namespace PowerFitness.Controllers;

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
    public async Task<ActionResult<IEnumerable<User>>> GetUsers(int pageSize, int pageToken)
    {
        var users = await _dataRepository.GetAllUsers(pageSize, pageToken);
        return users.Any() ? Ok(users) : NotFound();
    }
}