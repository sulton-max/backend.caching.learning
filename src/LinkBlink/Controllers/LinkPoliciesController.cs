using LinkForwarding.Core.Core.Models.Entities;
using LinkForwarding.Core.DataAccess.DataRepositories;
using Microsoft.AspNetCore.Mvc;

namespace LinkBlink.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LinkPoliciesController : ControllerBase
{
    private readonly IDataRepository _dataRepository;

    public LinkPoliciesController(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LinkPolicy>>> GetAllLinkPolicies([FromQuery] int pageSize, [FromQuery] int pageToken)
    {
        var linkPolicies = await _dataRepository.GetAllLinkPolicies(pageSize, pageToken);
        return linkPolicies.Any() ? Ok(linkPolicies) : NotFound();
    }
}